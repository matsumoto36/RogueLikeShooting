using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Bullet
{
    public abstract class BulletBase : MonoBehaviour, IBullet
    {
        protected BulletParameter bulletPara;

        // 弾プレハブ
        public string BulletPrefabPath;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SpawnCreate(Transform BulletPop)
        {
            // 弾丸の複製
            //GameObject bullets = Instantiate(bullet) as GameObject;
            // 弾の発射位置に移動
            //bullets.transform.position = BulletPop;
            var prefab = Resources.Load<GameObject>(BulletPrefabPath);
            Instantiate(prefab, BulletPop.position, BulletPop.rotation);
        }
    }
}
