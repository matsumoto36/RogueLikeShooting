using System.Linq;
using System.Threading;
using DDD.Katano.Managers;
using DDD.Katano.Model;
using DDD.Matsumoto;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using UniRx.Triggers;
using UnityEngine;

namespace DDD.Katano.View
{
	/// <summary>
	/// 階段
	/// </summary>
	public class StairView : MonoBehaviour
	{
		private const float NextFloorJumpTime = 3f;
		
		[SerializeField]
		private GamePlayers _gamePlayers;

		private MainGameManager _mainGameManager;
		
		private float _overlappedElapsedTime;
		
		private void Start()
		{
			var token = this.GetCancellationTokenOnDestroy();
			
			_mainGameManager = FindObjectOfType<MainGameManager>();

			OnPlayerRiding(token).Forget();
		}

		private async UniTaskVoid OnPlayerRiding(CancellationToken token = default)
		{
			while (!token.IsCancellationRequested)
			{
				// 当たっているプレイヤー
				var collidee = Physics.OverlapSphere(transform.position, 2, LayerMask.GetMask("Player"));
				int playerCount = 0;
				for (int i = 0; i < collidee.Length; i++)
				{
					var player = collidee[i].GetComponentInParent<PlayerCore>();
					if (player != null)
					{
						playerCount++;
					}
				}
				
				
				if (playerCount == _gamePlayers.JoinedPlayerCount)
					_overlappedElapsedTime += Time.fixedDeltaTime;
				else
					_overlappedElapsedTime = 0;

				if (_overlappedElapsedTime >= NextFloorJumpTime)
				{
					_mainGameManager.MainEventBroker.Publish(new MazeSignal.FloorEnded());
					return;
				}

				await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
			}
		}
	}
}