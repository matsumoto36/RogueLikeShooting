using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RogueLike.Nishiwaki.Item
{
    public class WeaponRangedLaser : WeaponRanged
    {
        Ray ray;        //レイ
        RaycastHit hit; //ヒットしたオブジェクト情報
        public float range;
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
                    range = hit.distance;
                }
            }
            else
            {
                range = 100.0f;
            }
        }

        public override void AttackUp()
        {
            iBullet.BulletCreate(transform);
        }
        public override void AttackDown()
        {

        }

    }
}
