using System.Collections;
using System.Collections.Generic;
using DDD.Nishiwaki.Item;
using UnityEngine;
using DDD.Nishiwaki.Bullet;

namespace DDD.Nishiwaki.Bullet
{
    public class BulletProjectileLaser : BulletBase
    {
        BulletObjectLaser bulletObjectLaser;
        public BulletProjectileLaser(BulletAsset asset, WeaponRanged weaponRanged) : base(asset, weaponRanged)
        {
        }

        public override void BulletCreate(Transform transform)
        {
            var bullet = UnityEngine.Object.Instantiate(LaserPrefab, transform);
            bullet.BulletPara = BulletPara;
            Debug.Log("LaserCreate");
        }
        public override void BulletDestroy()
        {
            //bulletObjectLaser.BulletDestroy();
        }
    }
}
