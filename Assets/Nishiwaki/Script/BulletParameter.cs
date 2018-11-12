using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Nishiwaki.Bullet
{
    [System.Serializable]

    public struct BulletParameter
    {
        public float Speed, Power;

        public BulletParameter(float speed, float power)
        {
            //とりあえず思いついたパラメーターたち
            Speed = speed;
            Power = power;
        }
    }
}