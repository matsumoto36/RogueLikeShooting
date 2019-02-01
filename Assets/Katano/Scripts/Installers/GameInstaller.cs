using DDD.Katano.Maze;
using DDD.Katano.Model;
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
		public GameObject PlayerPrefab;
		
		public override void InstallBindings()
		{
			Container.Bind<PlayerHealthProvider>().FromSubContainerResolve().ByMethod(InstallPlayerHealthProvider).AsSingle();
			
			Container.Bind<MessageBroker>().AsSingle();
			Container.Bind<IMessageReceiver>().To<MessageBroker>().FromResolve();
			Container.Bind<IMessagePublisher>().To<MessageBroker>().FromResolve();

			Container.Bind<MazeViewBuilder.Factory>().AsSingle();
			Container.Bind<PlayerBuilder>().AsSingle().WithArguments(PlayerPrefab);
			Container.Bind<EnemyBuilder>().AsSingle().WithArguments(PlayerPrefab);
			
			
			Container.BindInstance(PlayerSpawner).WhenInjectedInto<PlayerRoomComponent>();

			Container.Bind<PlayerSpawnerFactory>().AsSingle().WithArguments(PlayerSpawner);			
		}

		private void InstallPlayerHealthProvider(DiContainer container)
		{
			var playerAsset = Container.Resolve<PlayerAsset>();

			container.Bind<PlayerHealthProvider>().AsSingle().WithArguments(playerAsset.HP);
		}
	}
}