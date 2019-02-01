using System;
using System.Collections;
using DDD.Katano.View;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace DDD.Nishiwaki.Item
{
	public class WeaponRangedAuto : WeaponRanged
	{
		private WeaponBullet.Pool _weaponPool;
		
		public bool CanShot { get; private set; } = true;

		[Inject]
		private void Construct(WeaponBullet.Pool weaponPool)
		{
			_weaponPool = weaponPool;
		}
		
		public override void Attack()
		{
			if (!CanShot) return;
			CanShot = false;
			// 弾の発射位置
			
			CooldownAsync().Forget();
			
			Debug.Log("Attack()");
			
			// iBullet.BulletCreate(transform);

			_weaponPool.Spawn(characterCore, transform);
		}

		private async UniTaskVoid CooldownAsync()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(WeaponRangedPara.WaitTime));
			CanShot = true;
		}

		private void Update()
		{
			// デバッグ用
			if (Input.GetKey(KeyCode.Z)) Attack();
		}
	}
}