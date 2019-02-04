using DDD.Matsumoto.Navigation;
using Zenject;

namespace DDD.Katano.Installers
{
	public class MinimapInstaller : MonoInstaller<MinimapInstaller>
	{
		public MiniMapViewer MiniMapViewer;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<MiniMapSystem>().AsSingle();
			Container.Bind<MiniMapViewer>().FromComponentInNewPrefab(MiniMapViewer).AsSingle().NonLazy();
		}
	}
}