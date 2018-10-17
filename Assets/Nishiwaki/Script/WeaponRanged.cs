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

        // 仮の時間制限
        float WaitTime = 1.0f;
        public bool CanShot { get; private set; } = true;

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
            if (Input.GetKey(KeyCode.Z))
            {
                Attack();
            }
        }
        public void Attack()
        {
            if (!CanShot) return;
            CanShot = false;
            // 弾の発射位置
            StartCoroutine("canShot");
            ibullet.SpawnCreate(transform);
        }
        public void AttackUp()
        {
            //ibullet.SpawnCreate(transform);
        }
        public void AttackDown()
        {
            //ibullet.SpawnCreate(transform);
        }

        IEnumerator canShot()
        {
            yield return new WaitForSeconds(WaitTime);
            CanShot = true;
        }
    }
}
