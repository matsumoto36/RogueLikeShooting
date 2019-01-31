using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DDD.Matsumoto.Attack;

namespace DDD.Matsumoto.Character.EnemyAI {

	/// <summary>
	/// 敵のAI : 動かない
	/// </summary>
	public class EnemyAIStay : EnemyAIBase {

		public override void AIStart(EnemyCore enemy) {
			base.AIStart(enemy);

			enemy.Agent.updateRotation = false;
			enemy.Agent.updatePosition = false;
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

					//向きの設定
					enemy.ChangeAngle(dist);
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
			var sqrViewRadius = enemy.AIParameter.ViewRadius * enemy.AIParameter.ViewRadius;

			//視界チェック
			if(sqrLength > sqrViewRadius) return;
			Debug.Log("Radius");
			if(HasObstacleBetweenTarget(enemy, player)) return;
			Debug.Log("Obstacle");
			if(!CanViewAngleTarget(enemy.transform, dist, enemy.AIParameter.ViewAngle)) return;
			Debug.Log("ViewAngle");

			Target = player;

		}
	}
}
