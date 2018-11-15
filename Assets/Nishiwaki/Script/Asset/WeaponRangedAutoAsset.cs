using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Nishiwaki.Item
{
    [CreateAssetMenu(fileName = "WeaponRangedAutoAsset", menuName = "WeaponRanged/Create WeaponRangedAuto Asset")]

    public class WeaponRangedAutoAsset : WeaponRangedAsset
    {
        public float WaitTime;
    }
}
