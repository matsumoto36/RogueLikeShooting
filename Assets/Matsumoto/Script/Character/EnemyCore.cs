using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using DDD.Katano.Model;
using DDD.Matsumoto.Character.Asset;
using DDD.Matsumoto.Character.EnemyAI;
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

		public EnemyAIParameter AIParameter {
			get; protected set;
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

			var weapon = CharacterArm.EquippedArm;

			if (!IsAttack) {
				weapon?.AttackDown();
				IsAttack = true;
			}

			weapon?.Attack();
		}

		public override void ApplyDamage(IAttacker attacker, int damage) {
			base.ApplyDamage(attacker, damage);
			if(IsDead.Value) return;
			_enemyAI?.OnAttackedOther(this, attacker, damage);
		}

		public override void OnSpawn(CharacterAsset asset) {

			CharacterType = CharacterType.Enemy;

			var enemyAsset = (EnemyAsset)asset;

			//レイヤー設定
			gameObject.layer = LayerMask.NameToLayer("Enemy");

			//HPを設定
			_currentHealth.Value = enemyAsset.HP;
			_maxHealth = enemyAsset.HP;

			//AIの設定
			AIParameter = enemyAsset.EnemyAIParameter;
			switch(enemyAsset.EnemyAIType) {
				case EnemyAIType.Attacker:
					_enemyAI = new EnemyAIAttacker();
					break;
				case EnemyAIType.Ranger:
					_enemyAI = new EnemyAIRanger();
					break;
				case EnemyAIType.Stay:
					_enemyAI = new EnemyAIStay();
					break;
				default:
					break;
			}

			Agent = gameObject.AddComponent<NavMeshAgent>();
			//スピードの設定
			Agent.speed = 4;
			Agent.acceleration = 16;
			Agent.angularSpeed = enemyAsset.EnemyAIParameter.AngularSpeed;
		}


		private IReadOnlyReactiveProperty<bool> _isDead;

		public override IReadOnlyReactiveProperty<bool> IsDead
		{
			get
			{
				return _isDead ?? 
				       (_isDead = _currentHealth
					       .Select(x => x <= 0).ToReactiveProperty()
				       );
			}
		}

		protected override void Start() {

			this.UpdateAsObservable()
				.Subscribe(_ => {

					_enemyAI?.AIUpdate(this);

					if (_isAttackPrev && !IsAttack) {
						CharacterArm.EquippedArm?.AttackUp();
					}

					_isAttackPrev = IsAttack;
				})
				.AddTo(this);


			_enemyAI?.AIStart(this);
		}

		protected override void TakeDamage(IAttacker attacker, int value) {
			_currentHealth.Value = Mathf.Clamp(_currentHealth.Value - value, 0, _maxHealth);
			if(IsDead.Value) Kill(attacker);
		}

		private void OnDrawGizmosSelected() {

			void DrawCircle(Color color, Vector3 center, float radius, int pertition, float arc = Mathf.PI * 2,
				float radOffset = 0) {
				Gizmos.color = color;

				var prevPosition = center;
				var delta = 1.0 / pertition;
				for (int i = 0; i <= pertition; i++) {
					var rad = (float)(radOffset + delta * i * arc);
					var posOffset = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius;
					var position = center + posOffset;
					Gizmos.DrawLine(prevPosition, position);
					prevPosition = position;
				}
			}

			var centerPos = transform.position;


			//視界の表示
			var forward = transform.forward * AIParameter.ViewRadius;
			var start = Quaternion.Euler(0, AIParameter.ViewAngle / 2, 0) * forward;
			var end = Quaternion.Euler(0, -AIParameter.ViewAngle / 2, 0) * forward;
			Gizmos.color = Color.green;
			Gizmos.DrawLine(centerPos, start);
			Gizmos.DrawLine(centerPos, end);

			//ターゲット
			if (_enemyAI is EnemyAIBase aiBase) {
				if (aiBase.Target) {
					Gizmos.color = Color.red;
					Gizmos.DrawLine(centerPos, aiBase.Target.transform.position);
				}

			}

			switch (_enemyAI) {
				case EnemyAIAttacker aiAttacker:

					//移動開始距離の表示
					DrawCircle(Color.yellow, centerPos, AIParameter.MoveStartRadius, 32);

					break;
				case EnemyAIRanger aIRanger:

					//保つ距離の表示
					DrawCircle(Color.yellow, centerPos, AIParameter.KeepRange, 32);
					//移動開始範囲の表示
					DrawCircle(Color.blue, centerPos, AIParameter.KeepRange - AIParameter.MoveStartDifference, 32);
					DrawCircle(Color.blue, centerPos, AIParameter.KeepRange + AIParameter.MoveStartDifference, 32);
					break;
			}
		}
	}
}

