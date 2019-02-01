using System.Collections;
using UnityEngine;

namespace DDD.Nishiwaki.Item
{
	public class WeaponRangedAuto : WeaponRanged
	{
		public bool CanShot { get; private set; } = true;

		public override void Attack()
		{
			if (!CanShot) return;
			CanShot = false;
			// 弾の発射位置
			StartCoroutine(canShot());
			iBullet.BulletCreate(transform);
		}

		private IEnumerator canShot()
		{
			yield return new WaitForSeconds(WeaponRangedPara.WaitTime);
			CanShot = true;
		}

		private void Update()
		{
			// デバッグ用
			if (Input.GetKey(KeyCode.Z)) Attack();
		}
	}
}