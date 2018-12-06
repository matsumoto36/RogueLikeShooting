using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using RogueLike.Matsumoto.Character.Asset;

namespace RogueLike.Matsumoto.Character {

	/// <summary>
	/// 敵のクラス。AIで動かす
	/// </summary>
	public class EnemyCore : CharacterCore {

		float _attackWaitTime = 1.0f;
		IEnemyAI _enemyAI;

		private bool _isAttackPrev;

		public bool IsAttack {
			get; protected set;
		}

		public override int HP {
			get; protected set;
		}

		/// <summary>
		/// 移動する。AIが利用する。
		/// </summary>
		/// <param name="vec"></param>
		public void Move(Vector3 vec) {
			//武器依存で移動したい
			transform.position += vec * 4 * Time.deltaTime;
		}

		/// <summary>
		/// 指定された方向を向く。AIが利用する
		/// </summary>
		/// <param name="vec"></param>
		public void ChangeAngle(Vector3 vec) {

			//向きの変更
			transform.rotation = Quaternion.LookRotation(vec);
		}

		/// <summary>
		/// 攻撃する。AIが利用する。
		/// </summary>
		public void Attack() {

			if (!IsAttack) {
				Weapon?.AttackDown();
				IsAttack = true;
			}

			Weapon?.Attack();
		}

		/// <summary>
		/// 一番近いプレイヤーを返す
		/// </summary>
		/// <returns></returns>
		public PlayerCore RetrieveNearestPlayer() {
			return FindObjectsOfType<PlayerCore>()
				.OrderBy(item => (item.transform.position - transform.position).sqrMagnitude)
				.FirstOrDefault();
		}

		protected override void OnSpawn(CharacterAsset asset) {

			CharacterType = CharacterType.Enemy;

			var enemyAsset = (EnemyAsset)asset;

			//HPを設定
			HP = enemyAsset.HP;

			//AIの設定
			switch(enemyAsset.EnemyAIType) {
				case EnemyAIType.Attacker:
					_enemyAI = new EnemyAI.EnemyAIAttacker();
					break;
				default:
					break;
			}

		}

		protected override void Start() {

			this.UpdateAsObservable()
				.Subscribe(_ => {

					_enemyAI?.AIUpdate(this);

					if (_isAttackPrev && !IsAttack) {
						Weapon?.AttackUp();
					}

					_isAttackPrev = IsAttack;
				})
				.AddTo(this);

		}
	}
}

