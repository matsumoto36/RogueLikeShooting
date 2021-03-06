﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DDD.Matsumoto.Attack;

namespace DDD.Matsumoto.Character.EnemyAI {

	/// <summary>
	/// 敵のAI : アタッカー
	/// </summary>
	public class EnemyAIAttacker : EnemyAIBase {

		public override void AIUpdate(EnemyCore enemy) {
			base.AIUpdate(enemy);

			var enemyPos = enemy.transform.position;

			if(!Target) return;

			enemy.Attack();

			var targetPos = Target.transform.position;
			var dist = targetPos - enemyPos;
			var sqrLength = dist.sqrMagnitude;

			//移動先の設定
			var attackRadius = enemy.AIParameter.MoveStartRadius;
			if(sqrLength > Mathf.Pow(attackRadius + enemy.AIParameter.MoveStartDifference, 2))
				enemy.Agent.destination = targetPos;

		}

		public override void OnAttackedOther(EnemyCore enemy, IAttacker attacker, int damage) {
			base.OnAttackedOther(enemy, attacker, damage);

			//振りむき
			//Debug.Log("OnAttack");
			switch(attacker) {
				case CharacterAttacker cAttacker:
					enemy.Agent.SetDestination(cAttacker.Attacker.transform.position);
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

			//移動先の設定
			if(sqrLength > Mathf.Pow(enemy.AIParameter.MoveStartRadius, 2))
				enemy.Agent.destination = targetPos;
		}
	}
}
