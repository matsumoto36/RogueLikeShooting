using System;
using System.Collections;
using System.Threading;
using DDD.Katano;
using DDD.Katano.View;
using DDD.Matsumoto;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Unity.Linq;
using UnityEngine;
using Zenject;

namespace DDD.Nishiwaki.Item
{
	public class WeaponRangedAuto : WeaponRanged
	{
		private const float EnemyWeaponRateLimit = 2f;
		private WeaponBullet.Pool _bulletPool;
		private CancellationToken _token;
		
		public bool CanShot { get; private set; } = true;

		[Inject]
		private void Construct(WeaponBullet.Pool bulletPool)
		{
			_token = this.GetCancellationTokenOnDestroy();
			_bulletPool = bulletPool;

			MessageReceiver.Receive<MazeSignal.FloorDestruct>()
				.Subscribe(_ => gameObject.Destroy())
				.AddTo(this);
		}
		
		public override void Attack()
		{
			if (!CanShot) return;
			CanShot = false;
			// 弾の発射位置
			
			CooldownAsync(_token).Forget();
			
			Debug.Log("Attack()");
			
			// iBullet.BulletCreate(transform);

			_bulletPool.Spawn(characterCore, transform);

			//ショット音
			Matsumoto.Audio.AudioManager.PlaySE("se_maoudamashii_system42");
		}

		private async UniTaskVoid CooldownAsync(CancellationToken token = default)
		{
			await UniTask.Delay(TimeSpan.FromSeconds(characterCore.Alliance == CharacterType.Enemy ? WeaponRangedPara.WaitTime * EnemyWeaponRateLimit : WeaponRangedPara.WaitTime), cancellationToken: token);
			CanShot = true;
		}

		private void Update()
		{
			// デバッグ用
			if (Input.GetKey(KeyCode.Z)) Attack();
		}
	}
}