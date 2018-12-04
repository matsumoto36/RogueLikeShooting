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

        public override void BulletCreate(Transform transform)
        {
            var bullet = UnityEngine.Object.Instantiate(BulletPrefab, transform);
            bullet.BulletPara = BulletPara;
            Debug.Log("BulletCreate");
        }
    }
}