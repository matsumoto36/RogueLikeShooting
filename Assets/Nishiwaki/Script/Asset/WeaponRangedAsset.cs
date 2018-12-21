using System.Collections;
using System.Collections.Generic;
using DDD.Nishiwaki.Bullet;
using UnityEngine;

namespace DDD.Nishiwaki.Item
{
    public class WeaponRangedAsset : ScriptableObject
    {
        public WeaponRangedParameter WeaponRangedParameter;
        public GameObject WeaponRangedPrefab;
        public BulletAsset BulletAsset;
    }
}