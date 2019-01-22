using UniRx;
using Zenject;

namespace DDD.Katano
{
	public class DebugInstaller : MonoInstaller<DebugInstaller>
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<MessageBroker>().AsSingle();
		}
	}
}