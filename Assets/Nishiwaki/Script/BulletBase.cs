using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Bullet
{
    public abstract class BulletBase : IBullet
    {
        // 弾のパラメータ
        public BulletParameter BulletPara;
        // 弾プレハブ
        public BulletObject BulletPrefab;
        
        protected BulletBase(BulletAsset asset) {
            BulletPara = asset.BulletParameter;
            BulletPrefab = asset.BulletPrefab;
        }

        //public void SpawnCreate(Transform BulletPop)
        //{
        //    // 弾丸の複製
        //    //var prefab = Resources.Load<GameObject>(BulletPrefab);
        //    UnityEngine.Object.Instantiate(BulletPrefab, BulletPop.position, BulletPop.rotation);
        //}

        public void BulletCreate(Transform transform)
        {
            UnityEngine.Object.Instantiate(BulletPrefab, transform);
        }
        public static BulletBase Create(BulletAsset BulletAsset)
        {
            BulletBase BulletBase;

            // 弾の種類を判断
            switch (BulletAsset.BulletType)
            {
                case BulletType.Projectile:
                    BulletBase = new BulletProjectile(BulletAsset);
                    break;
                case BulletType.Lazer:
                    BulletBase = new BulletLezer(BulletAsset);
                    break;
                default:
                    BulletBase = null;
                    break;
            }
            return BulletBase;
        }

    }
}
