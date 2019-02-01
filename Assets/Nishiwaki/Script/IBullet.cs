using UnityEngine;

namespace DDD.Nishiwaki
{
	public interface IBullet
	{
		void BulletCreate(Transform transform);
		void BulletDestroy();
		void LaserRange(float Range);
	}
}