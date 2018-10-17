using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RogueLike.Matsumoto.Attack;
using UniRx;
using UniRx.Triggers;
using RogueLike.Nishiwaki;
using RogueLike.Nishiwaki.Item;

namespace RogueLike.Matsumoto.Character {

	/// <summary>
	/// プレイヤーの攻撃を行う
	/// </summary>
	[RequireComponent(typeof(PlayerCore))]
	public class PlayerAttack : MonoBehaviour {

		public IWeapon Weapon { get; private set; }

		void Start() {
			
			//装備
			var g = new GameObject("Weapon");
			g.transform.parent = transform;
			Weapon = g.AddComponent<WeaponRanged>();

			//攻撃
			GetComponent<PlayerCore>().PlayerUpdate
				.Where(player => player.InputEventProvider.GetShotButton())
				.Subscribe(player => Weapon?.Attack());
		}
	}
}
