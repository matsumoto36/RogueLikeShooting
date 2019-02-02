using DDD.Katano.Maze;
using DDD.Katano.Model;
using DDD.Katano.View.RoomComponents;
using DDD.Matsumoto;
using DDD.Matsumoto.Character.Asset;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace DDD.Katano.Installers
{
	public class GameCharactersInstaller : MonoInstaller<GameCharactersInstaller>
	{
		public GameObject CharacterPrefab;
		public GameObject PlayerSpawner;
		
		
		public override void InstallBindings()
		{
			Container.BindInstance(PlayerSpawner).WhenInjectedInto<PlayerRoomComponent>();
			
			Container.Bind<PlayerHealthProvider>()
				.FromSubContainerResolve()
				.ByMethod(InstallPlayerHealthProvider)
				.AsSingle();
			
			Container.Bind<MazeViewBuilder.Factory>().AsSingle();
			Container.Bind<PlayerBuilder>().AsSingle().WithArguments(CharacterPrefab);
			Container.Bind<EnemyBuilder>().AsSingle().WithArguments(CharacterPrefab);
			
			Container.Bind<PlayerSpawnerFactory>().AsSingle().WithArguments(PlayerSpawner);		
		}
		
		private static void InstallPlayerHealthProvider(DiContainer container)
		{
			var playerAsset = container.Resolve<PlayerAsset>();

			container.Bind<PlayerHealthProvider>().AsSingle().WithArguments(playerAsset.HP);
		}
	}
}