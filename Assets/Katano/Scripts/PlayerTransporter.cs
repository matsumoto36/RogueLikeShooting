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
	public class PlayerTransporter : MonoBehaviour
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
		/// <param name="nextRoom"></param>
		/// <returns></returns>
		public UniTask TransportAsync(RoomView nextRoom)
		{
			// TODO: Play Transport Animation
			return new UniTask(() => OnTransportInternal(nextRoom));
		}

		private async UniTask OnTransportInternal(RoomView nextRoom)
		{
			// プレイヤーの入力を停止
			foreach(var player in _gamePlayers.PlayerList) player.IsFreeze = true;
			
			await UniTask.WhenAll(_gamePlayers.PlayerList.Select(x => x.GetComponent<PlayerStateChanger>().DoChangeAsync(PlayerState.Photosphere)));
			
			await GameCamera.MoveAsync(nextRoom);
			
			await UniTask.WhenAll(_gamePlayers.PlayerList.Select(x => x.GetComponent<PlayerStateChanger>().DoChangeAsync(PlayerState.Neutral)));
			
			// プレイヤーの入力を再開
			foreach(var player in _gamePlayers.PlayerList) player.IsFreeze = false;

			nextRoom.Enter(_gamePlayers.PlayerList);
		}
	}
}