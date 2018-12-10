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

		void Start() {

			var playerComponent = GetComponent<PlayerCore>();

			//攻撃
			playerComponent.PlayerUpdate
				.Where(player => player.InputEventProvider != null)
				.Subscribe(player => {

					if(player.InputEventProvider.GetShotDown())
						player.Weapon?.AttackDown();

					if(player.InputEventProvider.GetShotButton())
						player.Weapon?.Attack();

					if(player.InputEventProvider.GetShotUp())
						player.Weapon?.AttackUp();

				});
		}
	}
}
