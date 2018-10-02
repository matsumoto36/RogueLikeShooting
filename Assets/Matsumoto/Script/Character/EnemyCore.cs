using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using System;

namespace RogueLike.Matsumoto.Character {

	/// <summary>
	/// 敵のクラス。AIで動かす
	/// </summary>
	public class EnemyCore : CharacterCore {

		float _attackWaitTime = 1.0f;
		IEnemyAI _enemyAI;

		public bool CanAttack {
			get; protected set;
		} = true;

		/// <summary>
		/// 移動する。AIが利用する。
		/// </summary>
		/// <param name="vec"></param>
		public void Move(Vector3 vec) {
			transform.position += vec * Parameter.MoveSpeed * Time.deltaTime;
		}

		/// <summary>
		/// 攻撃する。AIが利用する。
		/// </summary>
		/// <param name="target"></param>
		public void Attack(CharacterCore target) {

			if(!CanAttack) return;
			if(!target) return;

			CanAttack = false;
			Observable.Timer(TimeSpan.FromSeconds(_attackWaitTime)).Subscribe(_ => CanAttack = true);

			target.ApplyDamage(new Attack.CharacterAttacker(this), 20);
		}

		/// <summary>
		/// 一番近いプレイヤーを返す
		/// </summary>
		/// <returns></returns>
		public PlayerCore RetrieveNearestPlayer() {
			return FindObjectsOfType<PlayerCore>()
				.OrderBy((item) => (item.transform.position - transform.position).sqrMagnitude)
				.FirstOrDefault();
		}

		private void Start() {

			_enemyAI = new EnemyAI.EnemyAIAttacker();

		}

		private void Update() {

			_enemyAI?.AIUpdate(this);

		}

	}
}

