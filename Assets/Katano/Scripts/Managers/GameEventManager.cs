using UniRx;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Managers
{
	public class GameEventManager : MonoBehaviour
	{
//		[Inject]
//		private void Construct(IMessageReceiver messageReceiver)
//		{
//			messageReceiver
//				.Receive<MazeSignal.FloorEnded>()
//				.Subscribe(_ => GameFinalizeCoroutine().Forget())
//				.AddTo(this);
//
//			// プレイヤー全滅時イベントの購読
//			messageReceiver
//				.Receive<MazeSignal.PlayerKilled>()
//				.Subscribe(_ => GameOverCoroutine().Forget())
//				.AddTo(this);
//
//			messageReceiver
//				.Receive<MazeSignal.MazeCleared>()
//				.Subscribe(_ => GameClearCoroutine().Forget())
//				.AddTo(this);
//		}
	}
}