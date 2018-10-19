using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Nishiwaki.Item
{
    public struct WeaponRangedParameter
    {
        public IBullet ibullet;

        public float WaitTime;
        public int FireType;
        //enum FireType { Semi, Auto, Laser };

        public WeaponRangedParameter(float waittime, IBullet ibullet, int firetype)
        {
            //とりあえず思いついたパラメーターたち
            WaitTime = waittime;
            this.ibullet = ibullet;
            FireType = firetype;
        }
    }
}