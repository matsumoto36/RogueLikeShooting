using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike.Matsumoto.Character {
	public interface IEnemyAI {

		void AIUpdate(EnemyCore enemy);

	}
}
