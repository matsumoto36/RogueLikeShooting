using UnityEngine;
using System.Collections;
using UniRx;
using System.Linq;

namespace DDD.Matsumoto.Character.EnemyAI {

	public abstract class EnemyAIBase : IEnemyAI {

		protected readonly int RandomFrame = Random.Range(0, 60);

		private float _timer;
		private Vector3 _targetDirection;

		public PlayerCore Target {
			get; protected set;
		}

		public virtual void AIStart(EnemyCore enemy) {
			_timer = enemy.AIParameter.CheckTimer + RandomFrame * Time.deltaTime;
		}

		public virtual void AIUpdate(EnemyCore enemy) {
			//タイミングチェック
			if((_timer -= Time.deltaTime) < 0) {
				_timer += enemy.AIParameter.CheckTimer;
				AICheckTiming(enemy);
			}

			//向きの更新
			if(!enemy.Agent.updateRotation) {
				var transform = enemy.transform;
				transform.rotation =
					Quaternion.RotateTowards(
						transform.rotation, 
						Quaternion.Euler(0, transform.eulerAngles.y + Vector3.SignedAngle(transform.forward, _targetDirection, Vector3.up), 0),
						enemy.AIParameter.AngularSpeed * Time.deltaTime);
			}
		}

		public virtual void OnAttackedOther(EnemyCore enemy, IAttacker attacker, int damage) { }

		/// <summary>
		/// 何かのチェックを行うときに呼ばれる
		/// </summary>
		/// <param name="enemy"></param>
		public virtual void AICheckTiming(EnemyCore enemy) { }

		/// <summary>
		/// 向きたい向きを設定する
		/// </summary>
		public void SetRotarion(Vector3 direction) {
			_targetDirection = direction;
		}

		/// <summary>
		/// 一番近いプレイヤーを返す
		/// </summary>
		/// <returns></returns>
		public static PlayerCore RetrieveNearestPlayer(Vector3 enemyPosition) {
		return Object.FindObjectsOfType<PlayerCore>()
			.OrderBy(item => (item.transform.position - enemyPosition).sqrMagnitude)
			.FirstOrDefault();
		}

		/// <summary>
		/// ターゲットとの間に障害物があるか調べる
		/// </summary>
		/// <returns></returns>
		public static bool HasObstacleBetweenTarget(CharacterCore enemy, CharacterCore target) {

			var enemyPos = enemy.CharacterArm.EquippedArm.GetBody().transform.position;
			var targetPos = target.CharacterArm.EquippedArm.GetBody().transform.position;
			RaycastHit hitInfo;
			var hit = Physics.Linecast(enemyPos, targetPos, out hitInfo, ~LayerMask.GetMask("Player", "Enemy", "Bullet"));
			if(hit) {
				Debug.Log("hit : " + hitInfo.collider.name);
			}
			return hit;
		}

		/// <summary>
		/// 敵がターゲットを見ることができる角度かを調べる
		/// </summary>
		/// <returns></returns>
		public static bool CanViewAngleTarget(Transform enemy, Vector3 targetVec, float viewAngle) {
			return Vector3.Angle(enemy.forward, targetVec) <= viewAngle / 2;
		}
	}

}


