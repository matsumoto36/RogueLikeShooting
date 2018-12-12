using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRangedLaser : WeaponRanged
    {
        BulletParameter BulletPara;
        Ray ray;        //レイ
        RaycastHit hit; //ヒットしたオブジェクト情報
        public float Range;
        bool CanShot = true;
        public float ChargeTime;
        void Update()
        {
            //レイの設定
            ray = new Ray(transform.position, transform.forward);

            //レイキャスト（原点, 飛ばす方向, 衝突した情報, 長さ）
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //レイを可視化
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if (hit.distance <= 100)
                {
                    iBullet.LaserRange(hit.distance);
                }
            }
            else
            {
                iBullet.LaserRange(100.0f);
            }
        }

        public override void AttackUp()
        {
            iBullet.BulletDestroy();
        }
        public override void AttackDown()
        {
            iBullet.BulletCreate(transform);
        }
    }
}
