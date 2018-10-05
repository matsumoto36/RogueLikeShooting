using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RogueLike.Matsumoto.Attack;

namespace RogueLike.Matsumoto.Character {

	/// <summary>
	/// プレイヤーの攻撃を行う
	/// </summary>
	[RequireComponent(typeof(PlayerCore))]
	public class PlayerAttack : MonoBehaviour {

		//debug
		public CharacterCore Target;

		PlayerCore _playerCore;

		public void Update() {

			//とりあえず攻撃
			if(Input.GetMouseButtonDown(0)) {
				if(Target)
					Target.ApplyDamage(new CharacterAttacker(_playerCore), 20);
			}

		}

		void Start() {
			_playerCore = GetComponent<PlayerCore>();
		}

	}
}
