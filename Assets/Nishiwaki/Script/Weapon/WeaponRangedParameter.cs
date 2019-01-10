using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDD.Nishiwaki.Item
{
    [System.Serializable]
    public struct WeaponRangedParameter
    {
        public float WaitTime;
        //enum FireType { Semi, Auto, Laser };

        public WeaponRangedParameter(float waitTime)
        {
            //とりあえず思いついたパラメーターたち
            WaitTime = waitTime;
        }
    }
}