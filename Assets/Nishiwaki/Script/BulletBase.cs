using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Bullet
{
    public abstract class BulletBase : IBullet
    {
        public BulletParameter bulletPara;

        // 弾プレハブ
        public string BulletPrefabPath;

        //public float BulletSpeed, BulletPower;
        

        public void SpawnCreate(Transform BulletPop)
        {
            // 弾丸の複製
            var prefab = Resources.Load<GameObject>(BulletPrefabPath);
            UnityEngine.Object.Instantiate(prefab, BulletPop.position, BulletPop.rotation);
        }
    }
}
