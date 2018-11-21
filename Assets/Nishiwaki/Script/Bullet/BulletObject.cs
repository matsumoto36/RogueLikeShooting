using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Bullet;

namespace RogueLike.Nishiwaki.Bullet
{
    public class BulletObject : MonoBehaviour
    {

        public BulletParameter BulletPara;
        // 消滅用の時間
        float DestroyTime = 0.0f;

        // Use this for initialization
        void Start()
        {
            // BulletParameterからSpeed,Power,WaitTime
            //bulletPara = new BulletParameter(1.0f, 1.0f);
        }

        // Update is called once per frame
        void Update()
        {
            Rigidbody rig = GetComponent<Rigidbody>();

            Vector3 now = rig.position;

            now += transform.forward * BulletPara.Speed;

            rig.position = now;
            // 自動消滅の時間
            DestroyTime += Time.deltaTime;
            // 消滅
            if (DestroyTime >= BulletPara.LifeTime)
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