using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Nishiwaki.Bullet
{
    public struct BulletParameter
    {
        public float Speed, Power;

        public BulletParameter(float p1, float p2)
        {
            //とりあえず思いついたパラメーターたち
            Speed = p1;
            Power = p2;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}