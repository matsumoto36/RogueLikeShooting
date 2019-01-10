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
using UnityEngine.Serialization;

namespace DDD.Katano
{
	/// <summary>
	/// プレイヤー転送モジュール
	/// </summary>
	public class PlayerTransportSystem : MonoBehaviour
	{
		private const float TweenDuration = 2f;
		
		public GamePlayers GamePlayers;

		/// <summary>
		/// ゲームカメラ
		/// </summary>
		private GameCamera _gameCamera;

		private void Awake()
		{
			_gameCamera = FindObjectOfType<GameCamera>();
		}

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
			return new UniTask(() => OnTransportInternal(transporter));
		}

		private async UniTask OnTransportInternal(TransporterView transporter)
		{
			var destination = transporter.transform.position;
			var playerStateChangers = GamePlayers.PlayerList.Select(x => x.GetComponent<PlayerStateChanger>()).ToArray();
			
			// プレイヤーの入力を停止
			foreach(var player in GamePlayers.PlayerList) player.SetFreezeMode(true);
			
			await UniTask.WhenAll(playerStateChangers.Select(x => x.DoChangeAsync(PlayerState.Photosphere)));
			
			var transportAsyncEnumerable = GamePlayers.PlayerList
				.Select(player => DoMovePlayer(player, destination, TweenDuration))
				.Append(_gameCamera.MoveAsync(transporter.Owner));

			await UniTask.WhenAll(transportAsyncEnumerable);
			
			await UniTask.WhenAll(playerStateChangers.Select(x => x.DoChangeAsync(PlayerState.Neutral)));
			
			// プレイヤーの入力を再開
			foreach (var player in GamePlayers.PlayerList) player.SetFreezeMode(false);

			transporter.Owner.Enter(GamePlayers.PlayerList);
		}

		private UniTask DoMovePlayer(PlayerCore player, Vector3 endValue, float duration)
		{
			return new UniTask(player.transform.DOMove(endValue, duration).SetEase(Ease.Linear).Play().GetAwaiter());
		}
	}
}