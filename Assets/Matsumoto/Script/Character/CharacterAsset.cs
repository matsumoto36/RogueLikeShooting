﻿using UnityEngine;

namespace RogueLike.Matsumoto.Character {

	[CreateAssetMenu(fileName = "NewCharacterAsset", menuName = "Character/Create Characrer Asset")]
	public class CharacterAsset : ScriptableObject {

		public CharacterType CharacterType;
		public CharacterParameter CharacterParameter;
		public GameObject ModelPrefab;
		public EnemyAIType EnemyAIType;
	}
}