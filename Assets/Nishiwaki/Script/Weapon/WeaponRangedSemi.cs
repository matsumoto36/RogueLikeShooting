using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDD.Nishiwaki.Item
{
    public class WeaponRangedSemi : WeaponRanged
    {
        public override void AttackUp()
        {

        }
        public override void AttackDown()
        {
            iBullet.BulletCreate(transform);
        }
        void Update()
        {
            // デバッグ用
            if (Input.GetKeyDown(KeyCode.Z))
            {
                AttackDown();
            }
        }

    }
}
