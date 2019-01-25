using System;
using System.Linq;
using DDD.Katano.Model;
using DDD.Katano.View;
using DDD.Katano.View.Player;
using DDD.Matsumoto;
using DG.Tweening;
using Reqweldzen.Extensions;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace DDD.Katano
{
	/// <summary>
	/// プレイヤー転送モジュール
	/// </summary>
	public class PlayerTransportSystem : MonoBehaviour
	{
		private const float TweenDuration = 2f;
		
		[Inject]
		private GamePlayers _gamePlayers;

		/// <summary>
		/// ゲームカメラ
		/// </summary>
		[Inject]
		private GameCamera _gameCamera;

		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="initRoom"></param>
		public void Initialize(RoomView initRoom)
		{
			_gameCamera.Initialize(initRoom);
		}

		/// <summary>
		/// 転送
		/// </summary>
		/// <param name="transporter"></param>
		/// <returns></returns>
		public UniTask TransportAsync(TransporterView transporter)
		{
			if (transporter == null)
				throw new ArgumentNullException(nameof(transporter));
			
			// TODO: Play Transport Animation
			return new UniTask(() => TransportInternal(transporter));
		}

		private async UniTask TransportInternal(TransporterView transporter)
		{
			var destination = transporter.transform.position;
			var stateChangers =
				_gamePlayers.PlayerList.Select(x => x.GetComponent<PlayerStateChanger>()).ToList();
			
			// プレイヤーの入力を停止
			foreach(var player in _gamePlayers.PlayerList) player.SetFreezeMode(true);
			
			await UniTask.WhenAll(stateChangers.Select(x => x.DoChangeAsync(PlayerState.Photosphere)));
			
			var transportAsyncEnumerable = _gamePlayers.PlayerList
				.Select(player => DoMovePlayer(player, destination, TweenDuration))
				.Append(_gameCamera.MoveAsync(transporter.Owner));

			await UniTask.WhenAll(transportAsyncEnumerable);
			
			await UniTask.WhenAll(stateChangers.Select(x => x.DoChangeAsync(PlayerState.Neutral)));
			
			// プレイヤーの入力を再開
			foreach (var player in _gamePlayers.PlayerList) player.SetFreezeMode(false);

			transporter.Owner.Enter(_gamePlayers.PlayerList);
		}

		private static UniTask DoMovePlayer(PlayerCore player, Vector3 endValue, float duration)
		{
			return new UniTask(player.transform.DOMove(endValue, duration).SetEase(Ease.Linear).Play().GetAwaiter());
		}
	}
}