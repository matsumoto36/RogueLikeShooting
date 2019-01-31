using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DDD.Matsumoto.Attack;

namespace DDD.Matsumoto.Character.EnemyAI {

	/// <summary>
	/// 敵のAI : レンジャー
	/// </summary>
	public class EnemyAIRanger : EnemyAIBase {

		public override void AIStart(EnemyCore enemy) {
			base.AIStart(enemy);

			Debug.Log("AIStart");
			enemy.Agent.updateRotation = false;
		}

		public override void AIUpdate(EnemyCore enemy) {
			base.AIUpdate(enemy);

			var enemyPos = enemy.transform.position;

			if(!Target) return;

			enemy.Attack();

			var targetPos = Target.transform.position;
			var dist = targetPos - enemyPos;

			//向きの設定
			enemy.ChangeAngle(dist);
		}

		public override void OnAttackedOther(EnemyCore enemy, IAttacker attacker, int damage) {
			base.OnAttackedOther(enemy, attacker, damage);

			//振りむき
			//Debug.Log("OnAttack");
			switch(attacker) {
				case CharacterAttacker cAttacker:

					var targetPos = cAttacker.Attacker.transform.position;
					var dist = targetPos - enemy.transform.position;
					var pos = targetPos + -dist.normalized * enemy.AIParameter.KeepRange;

					//向きの設定
					enemy.ChangeAngle(dist);

					enemy.Agent.SetDestination(pos);
					AICheckTiming(enemy);
					break;
			}
		}

		public override void AICheckTiming(EnemyCore enemy) {
			base.AICheckTiming(enemy);

			Target = null;

			var enemyPos = enemy.transform.position;
			var player = RetrieveNearestPlayer(enemyPos);
			if(!player) return;

			var targetPos = player.transform.position;
			var dist = targetPos - enemyPos;
			var sqrLength = dist.sqrMagnitude;

			//視界チェック
			if(sqrLength > Mathf.Pow(enemy.AIParameter.ViewRadius, 2)) return;
			Debug.Log("RadiusPass");
			if(HasObstacleBetweenTarget(enemy, player)) return;
			Debug.Log("ObstaclePass");
			if(!CanViewAngleTarget(enemy.transform, dist, enemy.AIParameter.ViewAngle)) return;
			Debug.Log("ViewAnglePass");

			Target = player;

			//移動先の設定
			var pos = targetPos + -dist.normalized * enemy.AIParameter.KeepRange;

			//変化が一定値以上ある場合に移動
			if((pos - enemyPos).sqrMagnitude > Mathf.Pow(enemy.AIParameter.MoveStartDifference, 2))
				enemy.Agent.SetDestination(pos);

			//向きの設定
			enemy.ChangeAngle(dist);
		}
	}
}
