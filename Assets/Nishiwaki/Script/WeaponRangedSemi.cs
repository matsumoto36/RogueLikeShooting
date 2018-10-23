using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRangedSemi : WeaponRanged
    {
        WeaponRanged weaponRanged = new WeaponRanged();

        public override void AttackUp()
        {
        }
        public override void AttackDown()
        {
            weaponRanged.SpawnBulletPoint();
        }
    }
}
