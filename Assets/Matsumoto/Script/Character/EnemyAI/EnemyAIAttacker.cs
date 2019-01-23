using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DDD.Matsumoto.Character.EnemyAI {

	/// <summary>
	/// 敵のAI : アタッカー
	/// </summary>
	public class EnemyAIAttacker : IEnemyAI {

		private readonly int _randomFrame = Random.Range(0, 60);

		private float _attackRadius = 5f;
		private PlayerCore _target;

		public void AIStart(EnemyCore enemy) {

		}

		public void AIUpdate(EnemyCore enemy) {

			//一秒毎に、近いプレイヤーをターゲットにする
			if(!_target || (Time.frameCount + _randomFrame) % 60 == 0)
				_target = EnemyAIUtility.RetrieveNearestPlayer(enemy.transform.position);

			if(!_target) return;

			var dist = _target.transform.position - enemy.transform.position;

			if(dist.sqrMagnitude < Mathf.Pow(_attackRadius, 2))
				enemy.Attack();
			else {
				//移動

				enemy.Move(dist.normalized);
			}

			//向きの変更
			enemy.ChangeAngle(dist);

		}

	}
}
