using UnityEngine;

namespace RogueLike.Matsumoto.Character.Asset {

	[CreateAssetMenu(fileName = "NewEnemyAsset", menuName = "Character/Create Enemy Asset")]
	public class EnemyAsset : CharacterAsset {

		public EnemyAIType EnemyAIType;

	}
}
