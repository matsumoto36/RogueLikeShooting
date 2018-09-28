using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RogueLike.Matsumoto.Character;

namespace RogueLike.Matsumoto.Attack {

	public struct CharacterAttacker : IAttacker {

		public CharacterCore Attacker;

		public CharacterAttacker(CharacterCore attacker) {
			Attacker = attacker;
		}

	}
}
