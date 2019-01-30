using DDD.Katano.Maze;
using DDD.Katano.View.RoomComponents;
using DDD.Matsumoto;
using DDD.Matsumoto.Character;
using DDD.Matsumoto.Character.Asset;
using UniRx;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	/// <summary>
	/// ゲームシーンインストーラ
	/// </summary>
	public class GameInstaller : MonoInstaller<GameInstaller>
	{
		public GameObject PlayerSpawner;
		
		public override void InstallBindings()
		{
			Container.Bind<PlayerHealthProvider>().FromSubContainerResolve().ByMethod(InstallPlayerHealthProvider).AsSingle();
			
			Container.Bind<MessageBroker>().AsSingle();
			Container.Bind<IMessageReceiver>().To<MessageBroker>().FromResolve();
			Container.Bind<IMessagePublisher>().To<MessageBroker>().FromResolve();

			Container.Bind<CharacterCore.Factory>().AsSingle();
			Container.Bind<MazeViewBuilder.Factory>().AsSingle();

			Container.BindInstance(PlayerSpawner).WhenInjectedInto<PlayerRoomComponent>();

			Container.Bind<PlayerSpawnerFactory>().AsSingle().WithArguments(PlayerSpawner);

//			Container.Bind<CharacterSpawner[]>()
//				.FromSubContainerResolve()
//				.ByNewPrefabMethod(PlayerSpawner, ResolveCharacterSpawners);

//			Container.Bind<CharacterSpawner[]>().FromComponentsInNewPrefab(PlayerSpawner).AsTransient();
		}

		private void InstallPlayerHealthProvider(DiContainer container)
		{
			var playerAsset = Container.Resolve<PlayerAsset>();

			container.Bind<PlayerHealthProvider>().WithArguments(playerAsset.HP);
		}
		
		private void ResolveCharacterSpawners(DiContainer container)
		{
			
		}
	}
}