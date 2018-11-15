using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Nishiwaki.Bullet
{
    [System.Serializable]

    public struct BulletParameter
    {
        public float Speed, Power, LifeTime;

        public BulletParameter(float speed, float power, float lifeTime)
        {
            //とりあえず思いついたパラメーターたち
            // 速度
            Speed = speed;
            // 威力　今は使っていない
            Power = power;
            // 持続時間
            LifeTime = lifeTime;
        }
    }
}