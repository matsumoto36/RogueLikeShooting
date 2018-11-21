using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Item;

namespace RogueLike.Nishiwaki.Item
{
    public class WaeponRangedSpawner : MonoBehaviour
    {
        [SerializeField] WeaponRangedAsset WeaponRangedAsset;

        void Start()
        {
            WeaponRanged.Create(WeaponRangedAsset, transform);
        }
    }
}
