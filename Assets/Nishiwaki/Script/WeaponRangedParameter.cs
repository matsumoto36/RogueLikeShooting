using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Nishiwaki.Item
{
    [System.Serializable]
    public struct WeaponRangedParameter
    {
        public IBullet ibullet;

        public float WaitTime;
        //enum FireType { Semi, Auto, Laser };

        public WeaponRangedParameter(float waittime, IBullet ibullet)
        {
            //とりあえず思いついたパラメーターたち
            WaitTime = waittime;
            this.ibullet = ibullet;
        }
    }
}