using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki;
using RogueLike.Nishiwaki.Bullet;
using RogueLike.Matsumoto.Character;

namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRanged : MonoBehaviour, IWeapon
    {
        public IBullet iBullet;

        public WeaponRangedParameter WeaponRangedPara;
        public CharacterCore CharacterCore;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
        public void SpawnBulletPoint()
        {
            // 弾の発射位置
            iBullet.BulletCreate(transform);
        }

        public void SetOwner(CharacterCore character)
        {
            CharacterCore = character;
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
            WeaponRanged weapon;
            switch (asset)
            {
                case WeaponRangedAutoAsset AutoAsset:
                    weapon = obj.AddComponent<WeaponRangedAuto>();
                    break;
                case WeaponRangedSemiAsset SemiAsset:
                    weapon = obj.AddComponent<WeaponRangedSemi>();
                    break;
                case WeaponRangedLaserAsset LaserAsset:
                    weapon = obj.AddComponent<WeaponRangedLaser>();
                    break;
                default:
                    weapon = null;
                    break;
            }

            weapon.WeaponRangedPara = asset.WeaponRangedParameter;
            weapon.iBullet = BulletBase.Create(asset.BulletAsset, weapon);
            Debug.Log("WeaponRanged Create");

            return weapon;
        }


    }
}
