using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Matsumoto.Character {

	/// <summary>
	/// 敵のAIに実装されるインターフェース
	/// </summary>
	public interface IEnemyAI {

		void AIStart(EnemyCore enemy);

		void AIUpdate(EnemyCore enemy);

		void OnAttackedOther(EnemyCore enemy, IAttacker attacker, int damage);
	}
}
