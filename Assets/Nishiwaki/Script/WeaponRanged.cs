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
            //var bullet = new BulletProjectile();
            //bullet.BulletPrefabPath = "Bullet/NormalBullet";
        }

        // Update is called once per frame
        void Update()
        {
        }
        public void SpawnBulletPoint()
        {
            // 弾の発射位置
            weaponRangedPara.ibullet.BulletCreate(transform);
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

        public static WeaponRanged Create(WeaponRangedAsset asset, Transform Transform)
        {
            var obj = Instantiate(asset.WeaponRangedPrefab, Transform.position, Transform.rotation);
            var weapon = obj.AddComponent<WeaponRangedAuto>();
            weapon.weaponRangedPara = asset.WeaponRangedParameter;
            weapon.weaponRangedPara.ibullet = BulletBase.Create(asset.BulletAsset);

            return weapon;
        }
    }
}
