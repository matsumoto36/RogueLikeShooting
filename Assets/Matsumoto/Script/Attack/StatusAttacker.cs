using System.Collections;
using System.Collections.Generic;
using DDD.Matsumoto.Character;
using UnityEngine;
using UniRx;

namespace DDD.Matsumoto.Attack {

	/// <summary>
	/// キャラクターが攻撃したときに発生する情報
	/// </summary>
	public struct StatusAttacker : IAttacker {

		public CharacterCore StatusOwner;
		public IStatusChange Attacker;

		public StatusAttacker(CharacterCore owner, IStatusChange attacker) {
			StatusOwner = owner;
			Attacker = attacker;
		}

	}
}
