﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Nishiwaki.Item
{
    public struct WeaponRangedParameter
    {
        public IBullet ibullet;

        public float WaitTime;

        public WeaponRangedParameter(float waittime, IBullet ibullet)
        {
            //とりあえず思いついたパラメーターたち
            WaitTime = waittime;
            this.ibullet = ibullet;
        }
    }
}