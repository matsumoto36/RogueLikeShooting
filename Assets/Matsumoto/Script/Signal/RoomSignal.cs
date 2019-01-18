using UnityEngine;
using System.Collections;

namespace DDD.Matsumoto {

	public static class RoomSignal {

		/// <summary>
		/// 部屋に入ったとき
		/// </summary>
		public struct RoomStarted { }

		/// <summary>
		/// 部屋をクリアしたとき
		/// </summary>
		public struct RoomCleared { }

	}
}
