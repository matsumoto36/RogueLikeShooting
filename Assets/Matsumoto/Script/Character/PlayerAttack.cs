using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RogueLike.Matsumoto.Attack;
using UniRx.Triggers;
using RogueLike.Nishiwaki;
using RogueLike.Nishiwaki.Item;

namespace RogueLike.Matsumoto.Character {

	/// <summary>
	/// プレイヤーの攻撃を行う
	/// </summary>
	[RequireComponent(typeof(PlayerCore))]
	public class PlayerAttack : MonoBehaviour {

		private bool isUsingWeapon;

		void Start() {

			var playerComponent = GetComponent<PlayerCore>();

			//攻撃
			playerComponent.PlayerUpdate
				.Where(player => player.InputEventProvider != null)
				.Subscribe(player => {

					//武器切り替え時は攻撃キャンセル
					if (player.ChangeTargetWeapon != null) {
						if (!isUsingWeapon) return;

						player.Weapon?.AttackUp();
						isUsingWeapon = false;
						return;
					}

					if (player.InputEventProvider.GetShotDown() && !isUsingWeapon) {
						player.Weapon?.AttackDown();
						isUsingWeapon = true;
					}

					if(player.InputEventProvider.GetShotButton() && isUsingWeapon)
						player.Weapon?.Attack();

					if (player.InputEventProvider.GetShotUp() && isUsingWeapon) {
						player.Weapon?.AttackUp();
						isUsingWeapon = false;
					}

				});
		}
	}
}
