using System.Collections;
using System.Collections.Generic;
using DDD.Nishiwaki.Item;
using UnityEngine;
using DDD.Nishiwaki.Bullet;

namespace DDD.Nishiwaki.Bullet
{
    public class BulletProjectile : BulletBase
    {
        public BulletProjectile(BulletAsset asset, WeaponRanged weaponRanged) : base(asset, weaponRanged)
        {
        }

        public override void BulletCreate(Transform transform)
        {
            var bullet = UnityEngine.Object.Instantiate(BulletPrefab, transform.position, transform.rotation);
            bullet.BulletPara = BulletPara;
            bullet.weaponRanged = weaponRanged;
            Debug.Log("BulletCreate");
        }
    }
}