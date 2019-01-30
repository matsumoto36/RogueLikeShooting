using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using DDD.Katano.Model;
using DDD.Matsumoto.Character.Asset;
using UnityEngine.AI;

namespace DDD.Matsumoto.Character {

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

		public override WeaponAsset GetFirstWeapon { get; }

		private readonly IntReactiveProperty _currentHealth = new IntReactiveProperty();
		
		public override IReadOnlyReactiveProperty<int> CurrentHealth => _currentHealth;

		private int _maxHealth;
		public override int MaxHealth => _maxHealth;

		public NavMeshAgent Agent {
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

		protected override void OnSpawn(CharacterAsset asset) {

			CharacterType = CharacterType.Enemy;

			var enemyAsset = (EnemyAsset)asset;

			//レイヤー設定
			gameObject.layer = LayerMask.NameToLayer("Enemy");

			//HPを設定
			_currentHealth.Value = enemyAsset.HP;
			_maxHealth = enemyAsset.HP;

			//AIの設定
			switch(enemyAsset.EnemyAIType) {
				case EnemyAIType.Attacker:
					_enemyAI = new EnemyAI.EnemyAIAttacker();
					break;
				default:
					break;
			}

			Agent = gameObject.AddComponent<NavMeshAgent>();
			//スピードの設定
			//Agent.speed = 
		}

		public override IReadOnlyReactiveProperty<bool> IsDead { get; }

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


			_enemyAI?.AIStart(this);
		}
	}
}

