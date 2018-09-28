using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RogueLike.Matsumoto.Attack;

namespace RogueLike.Matsumoto.Character {

	[RequireComponent(typeof(PlayerCore))]
	public class PlayerAttack : MonoBehaviour {

		//debug
		public CharacterCore Target;

		private PlayerCore _playerCore;

		public void Update() {

			if(Input.GetMouseButtonDown(0)) {
				if(Target)
					Target.ApplyDamage(new CharacterAttacker(_playerCore), 20);
			}

		}

		private void Start() {
			_playerCore = GetComponent<PlayerCore>();
		}

	}
}
