using DDD.Matsumoto.Character.EnemyAI;
using UnityEngine;

namespace DDD.Matsumoto.Character.Asset {

	[CreateAssetMenu(fileName = "NewEnemyAsset", menuName = "Character/Create Enemy Asset")]
	public class EnemyAsset : CharacterAsset {

		public EnemyAIType EnemyAIType;
		public EnemyAIParameter EnemyAIParameter;

	}
}
