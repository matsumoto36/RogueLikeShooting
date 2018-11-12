using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Bullet
{
    public class BulletProjectile : BulletBase
    {
        public BulletProjectile(BulletAsset asset) : base(asset)
        {

        }

        public static BulletProjectile Create(BulletAsset asset, Transform Transform)
        {
            var obj = UnityEngine.Object.Instantiate(asset.BulletPrefab, Transform.position, Transform.rotation);
            var bullet = obj.AddComponent<BulletBase>();
            bullet.bulletPara = asset.BulletParameter;

            return bullet;
        }

    }
}