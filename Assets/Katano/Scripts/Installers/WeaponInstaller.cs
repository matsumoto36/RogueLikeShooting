using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	public class WeaponInstaller : MonoInstaller<WeaponInstaller>
	{
		public GameObject WeaponCore;
		
		public override void InstallBindings()
		{
			Container.Bind<RangedWeaponFactory>()
				.AsSingle()
				.WithArguments(WeaponCore);
		}
	}
}