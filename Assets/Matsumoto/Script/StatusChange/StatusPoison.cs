using UnityEngine;
using System.Collections;
using UniRx;
using System;
using DDD.Matsumoto.Attack;
using DDD.Matsumoto.Character;

namespace DDD.Matsumoto.StatusChange {

	/// <summary>
	/// 毒のステータス変化
	/// </summary>
	public class StatusPoison : StatusChangeBase {

		float startTime;

		public StatusPoison(float attachTime) : base(attachTime) {
			startTime = attachTime;
		}

		public override string GetStatusName() {
			return "Poison";
		}

		public override void OnAttachStatus(CharacterCore character) {

		}

		public override void OnUpdateStatus(CharacterCore character) {
			base.OnUpdateStatus(character);

			var interval = 1.0f;
			if(startTime - interval > RemainingTime.Value) {
				startTime -= interval;

				character.ApplyDamage(new StatusAttacker(character, this), 10);
			}
		}
	}
}


