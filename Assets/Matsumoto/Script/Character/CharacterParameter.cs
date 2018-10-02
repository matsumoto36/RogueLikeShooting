using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace RogueLike.Matsumoto.Character {

	/// <summary>
	/// キャラクターのパラメーター
	/// </summary>
	[Serializable]
	public struct CharacterParameter {

		public int HP;
		public float MoveSpeed;

		public CharacterParameter(int HP, float MoveSpeed) {
			this.HP = HP;
			this.MoveSpeed = MoveSpeed;
		}

	}
}
