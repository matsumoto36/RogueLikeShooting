using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DDD.Nishiwaki.Item;

namespace DDD.Nishiwaki.Item
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
