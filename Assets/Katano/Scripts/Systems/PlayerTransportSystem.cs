using System;
using System.Linq;
using DG.Tweening;
using Reqweldzen.Extensions;
using RogueLike.Katano.Model;
using RogueLike.Katano.View;
using RogueLike.Katano.View.Player;
using RogueLike.Matsumoto;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano
{
	/// <summary>
	/// プレイヤー転送モジュール
	/// </summary>
	public class PlayerTransportSystem : MonoBehaviour
	{
		private const float TweenDuration = 2f;
		
		[SerializeField]
		private GamePlayers _gamePlayers;

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
			var playerStateChangers = _gamePlayers.PlayerList.Select(x => x.GetComponent<PlayerStateChanger>()).ToArray();
			
			// プレイヤーの入力を停止
			foreach(var player in _gamePlayers.PlayerList) player.IsFreeze = true;
			
			await UniTask.WhenAll(playerStateChangers.Select(x => x.DoChangeAsync(PlayerState.Photosphere)));
			
			var transportAsyncs = _gamePlayers.PlayerList
				.Select(player => DoMovePlayer(player, destination, TweenDuration))
				.Append(_gameCamera.MoveAsync(transporter.Owner));

			await UniTask.WhenAll(transportAsyncs);
			
			await UniTask.WhenAll(playerStateChangers.Select(x => x.DoChangeAsync(PlayerState.Neutral)));
			
			// プレイヤーの入力を再開
			foreach(var player in _gamePlayers.PlayerList) player.IsFreeze = false;

			transporter.Owner.Enter(_gamePlayers.PlayerList);
		}

		private UniTask DoMovePlayer(PlayerCore player, Vector3 endValue, float duration)
		{
			return new UniTask(player.transform.DOMove(endValue, duration).SetEase(Ease.Linear).Play().GetAwaiter());
		}
	}
}