using DDD.Nishiwaki.Item;
using UnityEngine;
using Zenject;

namespace DDD.Nishiwaki.Bullet
{
	public abstract class BulletBase : IBullet
	{
		// 弾のパラメータ
		public BulletParameter BulletPara;

		// 弾プレハブ
		public BulletObject BulletPrefab;
		public BulletObjectLaser LaserPrefab;
		public WeaponRanged weaponRanged;

		protected BulletBase(BulletAsset asset, WeaponRanged weaponRanged)
		{
			BulletPara = asset.BulletParameter;
			BulletPrefab = asset.BulletPrefab;
			LaserPrefab = asset.LaserPrefab;
		}

		//public void BulletCreate(Transform transform)
		//{
		//    var bullet = UnityEngine.Object.Instantiate(BulletPrefab, transform);
		//    bullet.BulletPara = BulletPara;
		//    Debug.Log("BulletCreate");
		//}
		public virtual void BulletCreate(Transform transform)
		{
		}

		public virtual void BulletDestroy()
		{
		}

		public void LaserRange(float Range)
		{
			BulletPara.Range = Range;
		}

		public static BulletBase Create(BulletAsset BulletAsset, WeaponRanged weaponRanged)
		{
			BulletBase BulletBase;

			// 弾の種類を判断
			switch (BulletAsset.BulletType)
			{
				// 弾
				case BulletType.Projectile:
					BulletBase = new BulletProjectile(BulletAsset, weaponRanged);
					Debug.Log("Bulletrojectile");
					break;
				// レーザー
				case BulletType.Lazer:
					BulletBase = new BulletProjectileLaser(BulletAsset, weaponRanged);
					Debug.Log("BulletLaser");
					break;
				default:
					BulletBase = null;
					break;
			}

			BulletBase.weaponRanged = weaponRanged;

			return BulletBase;
		}
	}
}