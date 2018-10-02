using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike.Matsumoto.Character {

	/// <summary>
	/// 敵のAIに実装されるインターフェース
	/// </summary>
	public interface IEnemyAI {

		void AIUpdate(EnemyCore enemy);

	}
}
