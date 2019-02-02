using System;
using System.Collections;
using DDD.Katano.View;
using DDD.Matsumoto;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace DDD.Nishiwaki.Item
{
	public class WeaponRangedAuto : WeaponRanged
	{
		private const float EnemyWeaponRateLimit = 2f;
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

			//ショット音
			Matsumoto.Audio.AudioManager.PlaySE("se_maoudamashii_system42");
		}

		private async UniTaskVoid CooldownAsync()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(characterCore.Alliance == CharacterType.Enemy ? WeaponRangedPara.WaitTime * EnemyWeaponRateLimit : WeaponRangedPara.WaitTime));
			CanShot = true;
		}

		private void Update()
		{
			// デバッグ用
			if (Input.GetKey(KeyCode.Z)) Attack();
		}
	}
}