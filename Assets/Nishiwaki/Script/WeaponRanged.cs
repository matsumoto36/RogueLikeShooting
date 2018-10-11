using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRanged : MonoBehaviour, IWeapon
    {
        protected IBullet ibullet;

        // 弾丸発射点
        public Vector3 SpawnPoint;

        Vector3 BulletPop = new Vector3();
        
        // Use this for initialization
        void Start()
        {
            var bullet = new BulletProjectile();
            bullet.BulletPrefabPath = "Bullet/NormalBullet";
            ibullet = bullet;

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Attack();
            }
        }
        public void Attack()
        {
            // 弾の発射位置
            ibullet.SpawnCreate(transform.position);
        }
    }
}
