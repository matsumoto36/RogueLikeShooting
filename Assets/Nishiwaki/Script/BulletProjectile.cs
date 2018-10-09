using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoguLike.Nishiwaki.Bullet;

namespace RoguLike.Nishiwaki.Bullet
{
    public class BulletProjectile : BulletBase
    {
        // 弾プレハブ
        public GameObject bullet;

        // 弾丸発射点
        public Transform SpawnPoint;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            // z キーが押された時
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // 弾丸の複製
                GameObject bullets = Instantiate(bullet) as GameObject;
                // 弾の発射位置に移動
                bullets.transform.position = SpawnPoint.transform.position;
            }
        }
    }
}