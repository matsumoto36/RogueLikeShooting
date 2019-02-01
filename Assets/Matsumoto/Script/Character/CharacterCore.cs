using System.Collections.Generic;
using DDD.Katano.Model;
using DDD.Katano.View.Character;
using DDD.Matsumoto.Attack;
using DDD.Matsumoto.Character.Asset;
using DDD.Nishiwaki;
using UniRx;
using UniRx.Triggers;
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

		public CharacterType CharacterType { get; protected set; }
			= CharacterType.Invalid;

		public List<IStatusChange> StatusChanges { get; }
			= new List<IStatusChange>();

		public abstract IReadOnlyReactiveProperty<int> CurrentHealth { get; }
		
		public abstract int MaxHealth { get; }

		public IWeapon Weapon { get; private set; }

		public Color ThemeColor { get; set; }

		public abstract IReadOnlyReactiveProperty<bool> IsDead { get; }
		
		protected CharacterArm CharacterArm;

		public abstract WeaponAsset GetFirstWeapon { get; }

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
		public void ApplyDamage(IAttacker attacker, int damage)
		{
			switch (attacker)
			{
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

			Debug.Log($"{name}は{message}に倒された!");

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
		///     ステータス変化を取り付ける
		/// </summary>
		/// <param name="changer"></param>
		public void AttachStatus(IStatusChange changer)
		{
			StatusChanges.Add(changer);
			changer.OnAttachStatus(this);

			//効果時間が0以下になったら取り外す
			changer.RemainingTime
				.Where(x => x <= 0)
				.Subscribe(_ =>
				{
					changer.OnDetachStatus(this);
					StatusChanges.Remove(changer);
				})
				.AddTo(this);
		}

		public static bool IsAttackable(CharacterCore from, CharacterCore to)
		{
			if (!from || !to) return false;
			return from.CharacterType != to.CharacterType;
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