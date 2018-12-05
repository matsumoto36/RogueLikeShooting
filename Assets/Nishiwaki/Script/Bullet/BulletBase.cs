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
        public BulletObjectLaser LaserPrefab;

        protected BulletBase(BulletAsset asset) {
            BulletPara = asset.BulletParameter;
            BulletPrefab = asset.BulletPrefab;
            LaserPrefab = asset.LaserPrefab;
        }

        //public void BulletCreate(Transform transform)
        //{
        //    var bullet = UnityEngine.Object.Instantiate(BulletPrefab, transform);
        //    bullet.BulletPara = BulletPara;
        //    Debug.Log("BulletCreate");
        //}
        public virtual void BulletCreate(Transform transform)
        {
        }
        public virtual void BulletDestroy()
        {
        }

        public static BulletBase Create(BulletAsset BulletAsset)
        {
            BulletBase BulletBase;
            // 弾の種類を判断
            switch (BulletAsset.BulletType)
            {
                // 弾
                case BulletType.Projectile:
                    BulletBase = new BulletProjectile(BulletAsset);
                    Debug.Log("Bulletrojectile");
                    break;
                // レーザー
                case BulletType.Lazer:
                    BulletBase = new BulletProjectileLaser(BulletAsset);
                    Debug.Log("BulletLaser");
                    break;
                default:
                    BulletBase = null;
                    break;
            }
            return BulletBase;
        }
    }
}
