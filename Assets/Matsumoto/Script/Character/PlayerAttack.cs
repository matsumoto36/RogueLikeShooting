using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RogueLike.Matsumoto.Attack;
using RogueLike.Nishiwaki;
using RogueLike.Nishiwaki.Item;

namespace RogueLike.Matsumoto.Character {

	/// <summary>
	/// プレイヤーの攻撃を行う
	/// </summary>
	[RequireComponent(typeof(PlayerCore))]
	public class PlayerAttack : MonoBehaviour {

		public IWeapon Weapon { get; private set; }

		PlayerCore _playerCore;

		public void Update() {

			//とりあえず攻撃
			//if(_playerCore.InputEventProvider.GetShotButton()) {
			if(Input.GetMouseButtonDown(0))
				Weapon?.Attack();
			//}

		}

		void Start() {
			_playerCore = GetComponent<PlayerCore>();

			//装備
			var g = new GameObject("Weapon");
			g.transform.parent = transform;
			Weapon = g.AddComponent<WeaponRanged>();
		}

	}
}
