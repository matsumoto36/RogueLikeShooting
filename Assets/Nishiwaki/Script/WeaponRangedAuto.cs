using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRangedAuto : WeaponRanged
    {

        [SerializeField] BulletAsset BulletAsset;

        WeaponRanged weaponRanged = new WeaponRanged();

        public bool CanShot { get; private set; } = true;

        public override void Attack()
        {
            if (!CanShot) return;
            CanShot = false;
            // 弾の発射位置
            StartCoroutine(canShot());

            BulletProjectile.Create(BulletAsset, transform);
        }
        IEnumerator canShot()
        {
            yield return new WaitForSeconds(weaponRangedPara.WaitTime);
            CanShot = true;
        }
    }
}
