using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Bullet
{
    public class BulletObject : BulletBase
    {
        // Use this for initialization
        void Start()
        {
            // BulletParameterからSpeedとPower
            bulletPara = new BulletParameter(1, 1);
        }

        // Update is called once per frame
        void Update()
        {
            Rigidbody rig = GetComponent<Rigidbody>();

            Vector3 now = rig.position;
            // 銃に依存?
            now += new Vector3(1.0f, 0.0f, 0.0f);

            rig.position = now;
            //rig.position += Vector3.forward * bulletPara.Speed;
        }
        void OnTriggerEnter(Collider other)
        {
            // 敵に当たったら
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log("HIT");
                Destroy(gameObject);
            }
        }
    }
}