using DDD.Chikazawa;
using DDD.Matsumoto.Character;
using DDD.Matsumoto.Character.Asset;
using UnityEngine;
using Zenject;

namespace DDD.Matsumoto
{
	public class CharacterSpawner : MonoBehaviour
	{
		[Inject]
		private CharacterCore.Factory _characterFactory;

		[Inject]
		private PlayerBindData _bindData;

		[SerializeField]
		private CharacterAsset CharacterAsset;

		public int OverrideID;
		public bool PlayerIDOverride;

		public bool SpawnOnAwake;

		public CharacterCore Spawn()
		{
			switch (CharacterAsset)
			{
				case PlayerAsset asset:
					var id = asset.ID;
					if (PlayerIDOverride)
						asset.ID = OverrideID;


					// var player = CharacterCore.Create<PlayerCore>(asset, transform);
					var player = _characterFactory.Create<PlayerCore>(asset, transform);

					asset.ID = id;

					return player;
				case EnemyAsset asset:
//					return CharacterCore.Create<EnemyCore>(asset, transform);
					return _characterFactory.Create<EnemyCore>(asset, transform);
				default:
					return null;
			}
		}

		private void Start()
		{
			if (SpawnOnAwake) Spawn();
		}
	}
}