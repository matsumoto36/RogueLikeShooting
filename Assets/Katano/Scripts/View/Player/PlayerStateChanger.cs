using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano.View.Player
{
	/// <summary>
	/// プレイヤー状態変化クラス
	/// </summary>
	public class PlayerStateChanger : MonoBehaviour
	{
		public UniTask DoChangeAsync(PlayerState playerState)
		{
			return UniTask.CompletedTask;
		}

		/// <summary>
		/// プレイヤーステート
		/// </summary>
		public enum PlayerState
		{
			Neutral,
			Photosphere
		}
	}
}