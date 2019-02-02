using DDD.Matsumoto.Attack;
using DDD.Matsumoto.Character;
using DDD.Nishiwaki.Item;
using UniRx;
using UnityEngine;
using Zenject;
using DDD.Katano.Extensions;

namespace DDD.Nishiwaki.Bullet
{
	public class BulletObject : MonoBehaviour
	{
		[Inject]
		private IMessageReceiver _messageReceiver;
		
		private Rigidbody _rigidbody;
		private vfx_bullet _vfx;

		public BulletParameter BulletPara;

		// 消滅用の時間
		private float DestroyTime;
		public WeaponRanged weaponRanged;

		private void Start()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_vfx = GetComponent<vfx_bullet>();
			
			_vfx.muzzle();
		}

		private void Update()
		{
			var now = _rigidbody.position;

			now += transform.forward * (BulletPara.Speed * 0.1f);

			_rigidbody.position = now;
			// 自動消滅の時間
			DestroyTime += Time.deltaTime;
			// 消滅
			if (DestroyTime >= BulletPara.LifeTime) Destroy(gameObject);
		}

		// まだ仮
		private void OnTriggerEnter(Collider other)
		{
			// 敵に当たったら
			var character = other.GetComponentInParent<CharacterCore>();
			if (!character) return;
			if (character.IsAbleAttack(character))
			{
				// 敵にダメージを与える
				// nullの部分は攻撃者
				character.ApplyDamage(
					new CharacterAttacker(weaponRanged.characterCore), (int) BulletPara.Power);
				_vfx.damage();
			}
		}
	}
}