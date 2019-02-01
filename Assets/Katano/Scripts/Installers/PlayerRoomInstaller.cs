using DDD.Katano.View.RoomComponents;
using Zenject;

namespace DDD.Katano.Installers
{
	public class PlayerRoomInstaller : MonoInstaller<PlayerRoomInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<PlayerRoomComponent>().AsSingle();
			Container.Bind<TransportSystemComponent>().AsSingle();
		}
	}
}