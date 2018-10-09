using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RogueLike.Matsumoto.Character;

namespace RogueLike.Matsumoto.Attack {

	/// <summary>
	/// キャラクターが攻撃したときに発生する情報
	/// </summary>
	public struct CharacterAttacker : IAttacker {

		public CharacterCore Attacker;

		public CharacterAttacker(CharacterCore attacker) {
			Attacker = attacker;
		}

	}
}
