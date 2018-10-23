using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRangedAuto : WeaponRanged
    {
        WeaponRanged weaponRanged = new WeaponRanged();

        public bool CanShot { get; private set; } = true;

        public override void Attack()
        {
            if (!CanShot) return;
            CanShot = false;
            // 弾の発射位置
            StartCoroutine(canShot());
            weaponRanged.SpawnBulletPoint();
        }
        IEnumerator canShot()
        {
            yield return new WaitForSeconds(weaponRangedPara.WaitTime);
            CanShot = true;
        }
    }
}
