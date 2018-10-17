using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Bullet
{
    public class BulletObject : MonoBehaviour
    {
        BulletParameter bulletPara;
        // 消滅用の時間
        float DTime = 0f;

        // Use this for initialization
        void Start()
        {
            // BulletParameterからSpeed,Power,WaitTime
            bulletPara = new BulletParameter(1.0f, 1.0f);
        }

        // Update is called once per frame
        void Update()
        {
            Rigidbody rig = GetComponent<Rigidbody>();

            Vector3 now = rig.position;

            now += transform.forward * bulletPara.Speed;

            rig.position = now;
            // 自動消滅の時間
            DTime += 1 * Time.deltaTime;
            // 消滅
            if (DTime >= 3)
            {
                Destroy(gameObject);
            }
        }
        // まだ仮
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