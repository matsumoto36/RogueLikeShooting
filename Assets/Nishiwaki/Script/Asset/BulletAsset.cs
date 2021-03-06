﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDD.Nishiwaki.Bullet {

    [CreateAssetMenu(fileName = "NewBulletAsset", menuName = "Bullet/Create Bullet Asset")]

    public class BulletAsset : ScriptableObject {

        public BulletType BulletType;
        public BulletParameter BulletParameter;
        public BulletObject BulletPrefab;
        public BulletObjectLaser LaserPrefab;
    }
}