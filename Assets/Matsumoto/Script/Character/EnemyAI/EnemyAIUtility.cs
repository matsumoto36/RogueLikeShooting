using UnityEngine;
using System.Collections;
using UniRx;
using System.Linq;

namespace DDD.Matsumoto.Character.EnemyAI {

	public class EnemyAIUtility {

		/// <summary>
		/// 一番近いプレイヤーを返す
		/// </summary>
		/// <returns></returns>
		public static PlayerCore RetrieveNearestPlayer(Vector3 enemyPosition) {
			return Object.FindObjectsOfType<PlayerCore>()
				.OrderBy(item => (item.transform.position - enemyPosition).sqrMagnitude)
				.FirstOrDefault();
		}
	}

}


