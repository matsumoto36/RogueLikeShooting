using DDD.Katano.Extensions;
using DDD.Matsumoto.Attack;
using DDD.Matsumoto.Character;
using DDD.Nishiwaki.Bullet;
using UnityEngine;
using Zenject;

namespace DDD.Katano.View
{
	public class WeaponBullet : MonoBehaviour
	{
		
		public Rigidbody Rigidbody;
		public vfx_bullet VfxBullet;

		private CharacterCore _attacker;
		private float _destroyTime;
		private BulletParameter _parameter;
		private Pool _pool;

		[Inject]
		private void Construct( 
			BulletParameter parameter,
			Pool pool)
		{
			_parameter = parameter;
			_pool = pool;
		}
		
		private void Init(CharacterCore attacker, Transform origin)
		{
			_attacker = attacker;
			var trans = transform;
			trans.position = origin.position;
			trans.rotation = origin.rotation;
			_destroyTime = 0;
		}

		private void Update()
		{
			var now = Rigidbody.position;

			now += transform.forward * (_parameter.Speed * 0.1f);

			Rigidbody.position = now;

			_destroyTime += Time.deltaTime;

			if (_destroyTime >= _parameter.LifeTime)
			{
				_pool.Despawn(this);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			var character = other.GetComponentInParent<CharacterCore>();
			if (!character) return;

			if (_attacker.IsAbleAttack(character))
			{
				character.ApplyDamage(new CharacterAttacker(_attacker), (int)_parameter.Power);
				VfxBullet.damage();
			}

		}

		public class Pool : MonoMemoryPool<CharacterCore, Transform, WeaponBullet>
		{
			protected override void Reinitialize(CharacterCore attacker, Transform origin, WeaponBullet bullet)
			{
				bullet.Init(attacker, origin);
			}
		}
	}
}