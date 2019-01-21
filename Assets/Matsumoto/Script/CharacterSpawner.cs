using System.Collections;
using System.Collections.Generic;
using DDD.Chikazawa;
using DDD.Matsumoto.Character;
using DDD.Matsumoto.Character.Asset;
using UnityEngine;
using Zenject;

namespace DDD.Matsumoto {

	public class CharacterSpawner : MonoBehaviour {

		[SerializeField] CharacterAsset CharacterAsset;

		[SerializeField]
		private PlayerBindData BindData;

		[Inject]
		private CharacterCore.Factory _characterFactory;

		public bool SpawnOnAwake;
		public bool PlayerIDOverride;
		public int OverrideID;

		public CharacterCore Spawn() {

			switch(CharacterAsset) {
				case PlayerAsset asset:
					var id = asset.ID;
					if(PlayerIDOverride)
						asset.ID = OverrideID;

					
					var player = CharacterCore.Create<PlayerCore>(asset, transform);
					
					asset.ID = id;

					return player;
				case EnemyAsset asset:
					return CharacterCore.Create<EnemyCore>(asset, transform);
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
