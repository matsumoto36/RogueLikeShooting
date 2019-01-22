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
		public override void InstallBindings()
		{
			Container.Bind<CharacterCore.Factory>().AsSingle();
			
			Container.Bind<MessageBroker>().AsSingle();
			Container.Bind<IMessageReceiver>().To<MessageBroker>().FromResolve();
			Container.Bind<IMessagePublisher>().To<MessageBroker>().FromResolve();
		}
	}
}