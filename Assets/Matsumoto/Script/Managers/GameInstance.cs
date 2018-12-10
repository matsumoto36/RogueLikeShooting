﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLike.Nishiwaki;
using RogueLike.Nishiwaki.Item;

namespace RogueLike.Matsumoto.Managers {

	/// <summary>
	/// ゲーム中に保持しておきたい情報を持つクラス
	/// </summary>
	public static class GameInstance {

		public static List<IWeapon> AttachableWeaponList;

		/// <summary>
		/// 各データの初期化を行う
		/// </summary>
		public static void Reset() {

			AttachableWeaponList = null;
		}

	}
}
