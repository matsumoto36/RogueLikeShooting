using System.Collections.Generic;
using DDD.Katano.View.Character;
using DDD.Matsumoto.Attack;
using DDD.Matsumoto.Character.Asset;
using UniRx;
using UnityEngine;
using Zenject;

namespace DDD.Matsumoto.Character
{
	
	
	/// <summary>
	///     各キャラクターのコアクラス
	/// </summary>
	public abstract class CharacterCore : MonoBehaviour
	{
		[Inject]
		private IMessageReceiver _messageReceiver;

		public Rigidbody CharacterRig { get; set; }

		public CharacterType Alliance { get; protected set; }
			= CharacterType.Invalid;

		public abstract IReadOnlyReactiveProperty<int> CurrentHealth { get; }
		
		public abstract int MaxHealth { get; }

		public Color ThemeColor { get; set; }

		public abstract IReadOnlyReactiveProperty<bool> IsDead { get; }

		public CharacterArm CharacterArm { get; protected set; }

		private void Awake()
		{
			CharacterArm = GetComponent<CharacterArm>();
		}

		protected virtual void Start()
		{
			
		}

		/// <summary>
		///     ダメージを与える
		/// </summary>
		/// <param name="attacker"></param>
		/// <param name="damage"></param>
		public virtual void ApplyDamage(IAttacker attacker, int damage) {

			switch(attacker) {

				case CharacterAttacker cAttacker:

					var message = "Unknown";

					if (cAttacker.Attacker) message = cAttacker.Attacker.name;

					Debug.Log($"{message}は{name}に{damage}ダメージ与えた");

					break;
				default:
					Debug.Log($"Unknownは{name}に{damage}ダメージ与えた");
					break;
			}


			TakeDamage(attacker, damage);
		}

		protected abstract void TakeDamage(IAttacker attacker, int value);
		
		/// <summary>
		///     殺す
		/// </summary>
		/// <param name="attacker"></param>
		public virtual void Kill(IAttacker attacker)
		{
			var message = "";
			switch (attacker)
			{
				case CharacterAttacker cAttacker:

					//debug
					if (!cAttacker.Attacker)
					{
						message = "Unknown";
						break;
					}

					message = cAttacker.Attacker.name;
					break;
				case StatusAttacker sAttacker:
					message = sAttacker.StatusOwner.name + "の" + sAttacker.Attacker.GetStatusName();
					break;
				default:
					message = "Unknown";
					break;
			}

//			Debug.Log($"{name}は{message}に倒された!");

			Death();
		}

		/// <summary>
		///     キャラクターだ死んだときに呼ばれる
		/// </summary>
		public void Death()
		{
			//武器を放出
			CharacterArm.Detach();
			
			Destroy(gameObject);
		}

		/// <summary>
		///     生成された瞬間に呼ばれる
		/// </summary>
		/// <param name="asset"></param>
		public virtual void OnSpawn(CharacterAsset asset)
		{
		}
	}
}