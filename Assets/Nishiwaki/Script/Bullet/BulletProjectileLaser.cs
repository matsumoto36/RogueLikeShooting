using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Bullet
{
    public class BulletProjectileLaser : BulletBase
    {
        BulletObjectLaser bulletObjectLaser;
        public BulletProjectileLaser(BulletAsset asset) : base(asset)
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
            bulletObjectLaser.BulletDestroy();
        }
    }
}
