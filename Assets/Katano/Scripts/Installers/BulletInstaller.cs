using DDD.Katano.View;
using DDD.Nishiwaki.Bullet;
using DDD.Nishiwaki.Item;
using Zenject;

namespace DDD.Katano.Installers
{
	public class BulletInstaller : MonoInstaller<BulletInstaller>
	{
		public BulletParameter Parameter;
		public WeaponBullet BulletObject;
		
		public override void InstallBindings()
		{
			Container.BindInstance(Parameter);

			Container.BindMemoryPool<WeaponBullet, WeaponBullet.Pool>()
				.WithInitialSize(10)
				.FromComponentInNewPrefab(BulletObject)
				.UnderTransformGroup("Bullets");
		}
	}
}