using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Matsumoto.Character.EnemyAI {

	/// <summary>
	/// 敵のAI : アタッカー
	/// </summary>
	public class EnemyAIAttacker : IEnemyAI {

		float attackRadius = 1.5f;
		PlayerCore _target;
			   
		public void AIUpdate(EnemyCore enemy) {

			if(!_target || Time.frameCount % 60 == 0) _target = enemy.RetrieveNearestPlayer();
			if(!_target) return;

			var dist = _target.transform.position - enemy.transform.position;

			if(dist.sqrMagnitude < Mathf.Pow(attackRadius, 2))
				enemy.Attack();
			else
				enemy.Move(dist.normalized);

		}

	}
}
