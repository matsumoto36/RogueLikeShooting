using System.Linq;
using RogueLike.Katano.Managers;
using RogueLike.Katano.Model;
using RogueLike.Matsumoto;
using UniRx;
using UniRx.Async;
using UniRx.Triggers;
using UnityEngine;

namespace RogueLike.Katano.View
{
	/// <summary>
	/// 階段
	/// </summary>
	public class StairView : MonoBehaviour
	{
		private const float _nextFloorJumpTime = 3f;
		
		[SerializeField]
		private GamePlayers _gamePlayers;

		private MainGameManager _mainGameManager;
		
		private float _overlappedElapsedTime;
		
		private void Start()
		{
			_mainGameManager = FindObjectOfType<MainGameManager>();

			OnPlayerRiding().Forget();
		}

		private async UniTaskVoid OnPlayerRiding()
		{
			while (true)
			{
				// 当たっているプレイヤー
				var collidee = Physics.OverlapSphere(transform.position, 2, LayerMask.NameToLayer("Player"));
				if (collidee.Length == _gamePlayers.JoinedPlayerCount)
					_overlappedElapsedTime += Time.fixedDeltaTime;
				else
					_overlappedElapsedTime = 0;

				if (_overlappedElapsedTime >= _nextFloorJumpTime)
				{
					_mainGameManager.MainEventBroker.Publish(new MazeSignal.FloorEnded());
					return;
				}

				await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
			}
		}
	}
}