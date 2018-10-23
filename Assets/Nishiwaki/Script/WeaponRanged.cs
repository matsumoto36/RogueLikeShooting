using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRanged : MonoBehaviour, IWeapon
    {
        public WeaponRangedParameter weaponRangedPara;

        // Use this for initialization
        void Start()
        {
            var bullet = new BulletProjectile();
            bullet.BulletPrefabPath = "Bullet/NormalBullet";

            weaponRangedPara = new WeaponRangedParameter(0.1f, bullet);
        }

        // Update is called once per frame
        void Update()
        {
            // デバッグ用
            if (Input.GetKey(KeyCode.Z))
            {

            }
            if (Input.GetMouseButtonUp(0))
            {

            }
            if (Input.GetKeyUp(KeyCode.Z))
            {

            }
        }
        public void SpawnBulletPoint()
        {
            // 弾の発射位置
            weaponRangedPara.ibullet.SpawnCreate(transform);
        }

        public virtual void Attack()
        {
        }

        public virtual void AttackUp()
        {
        }

        public virtual void AttackDown()
        {
        }
    }
}
