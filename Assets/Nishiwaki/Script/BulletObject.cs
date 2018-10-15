using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Bullet
{
    public class BulletObject : MonoBehaviour
    {
        BulletParameter bulletbase;
        // 消滅用の時間
        float DTime = 0f;

        // Use this for initialization
        void Start()
        {
            // BulletParameterからSpeedとPower
            bulletbase = new BulletParameter(1, 1);
            //bulletbase.BulletSpeed = 1.0f;
            //bulletbase.BulletPower = 1.0f;
        }

        // Update is called once per frame
        void Update()
        {
            Rigidbody rig = GetComponent<Rigidbody>();

            Vector3 now = rig.position;
            // 銃に依存?
            //now += transform.forward * bulletbase.BulletSpeed;
            now += transform.forward * bulletbase.Speed;

            rig.position = now;

            DTime += 1 * Time.deltaTime;

            if (Time.deltaTime >= 3)
            {
                Destroy(gameObject);
            }
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