using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Matsumoto.Character;

namespace RogueLike.Matsumoto {

	public class CharacterSpawner : MonoBehaviour {

		[SerializeField] CharacterAsset CharacterAsset;

		public bool SpawnOnAwake;


		public CharacterCore Spawn() {

			switch(CharacterAsset.CharacterType) {
				case CharacterType.Player:
					return CharacterCore.Create<PlayerCore>(CharacterAsset, transform);
				case CharacterType.Enemy:
					return CharacterCore.Create<EnemyCore>(CharacterAsset, transform);
				default:
					return null;
			}
		}

		void Start() {
			if(SpawnOnAwake) Spawn();
		}

		void OnDrawGizmos() {
			
		}
	}
}
