using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Item;

namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRangedSpawner : MonoBehaviour
    {
        [SerializeField] WeaponRangedAsset weaponRangedAsset;

        void Start()
        {
            WeaponRanged.Create(weaponRangedAsset, transform);
        }
    }
}
