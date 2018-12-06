using System;
using RogueLike.Katano.Model;
using UniRx;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano
{
	public class PlayerTransporter : MonoBehaviour
	{
		[SerializeField]
		private GamePlayers _gamePlayers;

		public IObservable<Unit> Transport()
		{
			// TODO: Play Transport Animation
			return OnTransportInternal().ToObservable();
		}

		private async UniTask OnTransportInternal()
		{
			// foreach(var player in _gamePlayers.PlayerList) player.IsFreeze = true;
			
			// await UniTask.WhenAll(_gamePlayers.PlayerList.Select(x => x.DoChangeAsync(Status.Photosphere)));
			
			// await GameCamera.MoveAsync(NextRoom);
			
			// await UniTask.WhenAll(_gamePlayers.PlayerList.Select(x => x.DoChangeAsync(Status.Neutral)));
			
			// foreach(var player in _gamePlayers.PlayerList) player.IsFreeze = false;
		}
	}
}