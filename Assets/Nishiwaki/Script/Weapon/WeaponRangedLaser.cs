using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRangedLaser : WeaponRanged
    {
        BulletParameter bulletParameter;
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
                    Range = hit.distance;
                }
            }
            else
            {
                Range = 100.0f;
            }

            // デバッグ用
            if (Input.GetKeyUp(KeyCode.Z))
            {
                AttackUp();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                AttackDown();
            }
            bulletParameter.Range = Range;
            //if (!CanShot)
            //{
            //    ChargeTime += Time.deltaTime;
            //    Debug.Log(ChargeTime);
            //}
        }

        public override void AttackUp()
        {
            
        }
        public override void AttackDown()
        {
            //if (CanShot)
            //{
            //    ChargeTime = 0;
            //    CanShot = false;
            //}
            iBullet.BulletCreate(transform);
        }

    }
}
