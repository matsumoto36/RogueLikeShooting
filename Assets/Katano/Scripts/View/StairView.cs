using System.Linq;
using System.Threading;
using RogueLike.Katano.Managers;
using RogueLike.Katano.Model;
using RogueLike.Matsumoto;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using UniRx.Triggers;
using UnityEngine;

namespace RogueLike.Katano.View
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
				var collidee = Physics.OverlapSphere(transform.position, 2, LayerMask.NameToLayer("Player"));
				if (collidee.Length == _gamePlayers.JoinedPlayerCount)
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