using System;
using System.Linq;
using DG.Tweening;
using Reqweldzen.Extensions;
using RogueLike.Katano.Model;
using RogueLike.Katano.View;
using RogueLike.Katano.View.Player;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano
{
	/// <summary>
	/// プレイヤー転送モジュール
	/// </summary>
	public class PlayerTransportSystem : MonoBehaviour
	{
		[SerializeField]
		private GamePlayers _gamePlayers;

		/// <summary>
		/// ゲームカメラ
		/// </summary>
		public GameCamera GameCamera;

		public void Initialize(RoomView initRoom)
		{
			GameCamera.Initialize(initRoom);
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
			// プレイヤーの入力を停止
			foreach(var player in _gamePlayers.PlayerList) player.IsFreeze = true;
			
			await UniTask.WhenAll(_gamePlayers.PlayerList.Select(x => x.GetComponent<PlayerStateChanger>().DoChangeAsync(PlayerState.Photosphere)));
			
			var playerMoveAsync = _gamePlayers.PlayerList
				.Select(player => player.transform
						.DOMove(transporter.transform.position, 2f)
						.SetEase(Ease.Linear)
						.Play().ToUniTask())
				.Append(GameCamera.MoveAsync(transporter.Owner));

			await UniTask.WhenAll(playerMoveAsync);
			
			await UniTask.WhenAll(_gamePlayers.PlayerList.Select(x => x.GetComponent<PlayerStateChanger>().DoChangeAsync(PlayerState.Neutral)));
			
			// プレイヤーの入力を再開
			foreach(var player in _gamePlayers.PlayerList) player.IsFreeze = false;

			transporter.Owner.Enter(_gamePlayers.PlayerList);
		}
	}
}