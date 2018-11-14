using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRangedAuto : WeaponRanged
    {
        public bool CanShot { get; private set; } = true;

        public override void Attack()
        {
            if (!CanShot) return;
            CanShot = false;
            // 弾の発射位置
            StartCoroutine(canShot());
            Debug.Log("Attack()");
            iBullet.BulletCreate(transform);
        }
        IEnumerator canShot()
        {
            yield return new WaitForSeconds(WeaponRangedPara.WaitTime);
            CanShot = true;
        }
        void Update()
        {
            // デバッグ用
            if (Input.GetKey(KeyCode.Z))
            {
                Attack();
            }
        }

    }
}
