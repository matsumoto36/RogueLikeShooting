using UnityEngine;
using System.Collections;
using RogueLike.Matsumoto.Character;
using UniRx;
using System;

namespace RogueLike.Matsumoto.StatusChange {

	/// <summary>
	/// ステータス変化の共通分
	/// </summary>
	public abstract class StatusChangeBase : IStatusChange {

		protected CharacterCore _character;

		public ReactiveProperty<float> RemainingTime {
			get; protected set;
		}

		public StatusChangeBase(float attachTime) {
			RemainingTime = new ReactiveProperty<float>(attachTime);
		}

		public virtual IStatusChange GetMixedStatusChange(IStatusChange other) {
			return null;
		}

		public abstract string GetStatusName();

		public virtual void OnAttachStatus(CharacterCore character) { }

		public virtual void OnDetachStatus(CharacterCore character) { }

		public virtual void OnUpdateStatus(CharacterCore character) {
			RemainingTime.Value -= Time.deltaTime;
		}
	}
}
