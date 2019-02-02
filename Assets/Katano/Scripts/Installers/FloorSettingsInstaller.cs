using DDD.Katano.Managers;
using Zenject;

namespace DDD.Katano.Installers
{
	public class FloorSettingsInstaller : MonoInstaller<FloorSettingsInstaller>
	{
		public MainGameManager.FloorSettings MainFloorSettings;

		public override void InstallBindings()
		{
			Container.BindInstance(MainFloorSettings);
		}
	}
}