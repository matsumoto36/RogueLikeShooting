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

        void Start()
        {
        }

        void Update()
        {
            Rigidbody rig = GetComponent<Rigidbody>();

            Vector3 now = rig.position;

            now += transform.forward * (BulletPara.Speed * 0.1f);

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
            var enemy = other.GetComponentInParent<Matsumoto.Character.EnemyCore>();
            if (enemy)
            {
                // 敵にダメージを与える
                // nullの部分は攻撃者
                enemy.ApplyDamage(
                    new Matsumoto.Attack.CharacterAttacker(null), (int)BulletPara.Power);
                Destroy(gameObject);
            }
        }
    }
}