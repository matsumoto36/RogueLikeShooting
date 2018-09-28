using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RogueLike.Matsumoto.Attack;

namespace RogueLike.Matsumoto.Character {

	public abstract class CharacterCore : MonoBehaviour {

		[SerializeField]
		protected CharacterParameter _parameter;

		public CharacterParameter Parameter {
			get { return _parameter; }
			protected set { _parameter = value; }
		}

		public void ApplyDamage(IAttacker attacker, int damage) {

			var message = "";
			if(attacker == null)
				message = "Unknown";
			if(attacker is CharacterAttacker)
				message = ((CharacterAttacker)attacker).Attacker.name;

			Debug.Log($"{message}は{name}に{damage}ダメージ与えた");

			_parameter.HP -= damage;
			if(_parameter.HP <= 0) {
				_parameter.HP = 0;
				Kill(attacker);
			}
		}

		public void Kill(IAttacker attacker) {

			var message = "";
			if(attacker == null)
				message = "Unknown";
			if(attacker is CharacterAttacker)
				message = ((CharacterAttacker)attacker).Attacker.name;

			Debug.Log($"{name}は{message}に倒された!");

			Destroy(gameObject);
		}

	}
}
