using System.Collections;
using System.Threading;
using DDD.Katano.Model;
using DDD.Matsumoto;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;
using Zenject;

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

		[InjectOptional]
		private IMessagePublisher _messagePublisher;
		
		private float _overlappedElapsedTime;
		
		private void Start()
		{
			var token = this.GetCancellationTokenOnDestroy();

			OnPlayerEnter(token).Forget();
			
			
		}

		private async UniTaskVoid OnPlayerEnter(CancellationToken token = default)
		{
			while (!token.IsCancellationRequested)
			{
				// 当たっているプレイヤー
				var collidee = Physics.OverlapSphere(transform.position, 2, LayerMask.GetMask("Player"));
				var playerCount = 0;
				for (var i = 0; i < collidee.Length; i++)
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
					_messagePublisher.Publish(new MazeSignal.FloorEnded());
					return;
				}

				await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
			}
		}
	}
}