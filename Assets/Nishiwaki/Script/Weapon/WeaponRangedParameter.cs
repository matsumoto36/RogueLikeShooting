using System;

namespace DDD.Nishiwaki.Item
{
	[Serializable]
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