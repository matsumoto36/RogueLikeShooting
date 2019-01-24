using System.Collections;
using System.Collections.Generic;
using DDD.Matsumoto.Attack;
using DDD.Matsumoto.Character.Asset;
using DDD.Nishiwaki;
using DDD.Nishiwaki.Item;
using UnityEngine;
using DDD.Katano.Managers;
using UniRx;
using UniRx.Triggers;
using Zenject;

namespace DDD.Matsumoto.Character {

	/// <summary>
	/// 各キャラクターのコアクラス
	/// </summary>
	public abstract partial class CharacterCore : MonoBehaviour {

		public const string CharacterPrefabPath = "Prefab/CharacterPrefab";

		public Rigidbody CharacterRig { get; private set; }

		[Inject]
		//Todo エラー回避を適当に
		private IMessageReceiver _messageReceiver;

		private readonly ReactiveProperty<bool> _isDead
			= new BoolReactiveProperty();

		public CharacterType CharacterType { get; protected set; }
			= CharacterType.Invalid;

		public List<IStatusChange> StatusChanges { get; protected set; }
			= new List<IStatusChange>();

		public IWeapon Weapon { get; private set; }

		public abstract int HP {
			get; protected set;
		}

		private Color _themeColor;
		public Color ThemeColor {
			get { return _themeColor; }
		}

		public IReadOnlyReactiveProperty<bool> IsDead => _isDead;

		/// <summary>
		/// 武器を装備する
		/// </summary>
		/// <param name="weapon"></param>
		public void AttachWeapon(IWeapon weapon) {

			//武器を外す
			DetachWeapon();

			//武器を付ける
			Weapon = weapon;
			if (Weapon == null) return;

            Weapon.SetOwner(this);

			//武器の本体を取得し、子にする
			var body = Weapon.GetBody().transform;
			transform.rotation = body.rotation;
			transform.position = body.position;
			body.SetParent(transform);

		}

		/// <summary>
		/// 武器を外す
		/// </summary>
		public void DetachWeapon() {
			if (Weapon == null) return;

			//武器のオーナーを解除
			Weapon.SetOwner(null);

			//武器の本体を取得し、子から外す
			Weapon.GetBody()
				.transform
				.SetParent(null);

			Weapon = null;
			
		}

		/// <summary>
		/// ダメージを与える
		/// </summary>
		/// <param name="attacker"></param>
		/// <param name="damage"></param>
		public void ApplyDamage(IAttacker attacker, int damage) {

			switch(attacker) {
				case CharacterAttacker cAttacker:

					var message = "Unknown";

					if(cAttacker.Attacker) {
						message = cAttacker.Attacker.name;
					}

					Debug.Log($"{message}は{name}に{damage}ダメージ与えた");

					break;
				default:
					Debug.Log($"Unknownは{name}に{damage}ダメージ与えた");
					break;
			}


			HP -= damage;
			if(HP <= 0) {
				HP = 0;
				Kill(attacker);
			}
		}

		/// <summary>
		/// 殺す
		/// </summary>
		/// <param name="attacker"></param>
		public virtual void Kill(IAttacker attacker) {

			var message = "";
			switch(attacker) {

				case CharacterAttacker cAttacker:

					//debug
					if(!cAttacker.Attacker) {
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
		/// キャラクターだ死んだときに呼ばれる
		/// </summary>
		protected virtual void Death() {

			//武器を放出
			DetachWeapon();

			//死亡通知
			_isDead.Value = true;

			Destroy(gameObject);
		}

		/// <summary>
		/// ステータス変化を取り付ける
		/// </summary>
		/// <param name="changer"></param>
		public void AttachStatus(IStatusChange changer) {

			StatusChanges.Add(changer);
			changer.OnAttachStatus(this);

			//効果時間が0以下になったら取り外す
			changer.RemainingTime
				.Where(x => x <= 0)
				.Subscribe(_ => {

					changer.OnDetachStatus(this);
					StatusChanges.Remove(changer);
				})
				.AddTo(this);
		}

		/// <summary>
		/// アセットから自身を生成する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="asset"></param>
		/// <param name="spawnTransform"></param>
		/// <returns></returns>
		public static T Create<T>(CharacterAsset asset, Transform spawnTransform) where T : CharacterCore {

			//本体の生成

			var obj = Instantiate(Resources.Load<GameObject>(CharacterPrefabPath), spawnTransform.position,
				spawnTransform.rotation);

			obj.name = asset.name;

			var character = obj.AddComponent<T>();
			character._themeColor = asset.ThemeColor;
			character.CharacterRig = character.GetComponent<Rigidbody>();

			character.OnSpawn(asset);
			var weapon = WeaponRanged.Create(asset.Weapon, spawnTransform);
			character.AttachWeapon(weapon);

			return character;
		}

		public static bool IsAttackable(CharacterCore from, CharacterCore to) {
			if (!from || !to) return false;
			return from.CharacterType != to.CharacterType;
		}

		protected virtual void Start() {

			//フロア破壊時
			//_messageReceiver
			//	.Receive<Katano.MazeSignal.FloorDestruct>()
			//	.Where((_) => _isDead.Value)
			//	.Subscribe((_) => Destroy(gameObject))
			//	.AddTo(this);

			this.UpdateAsObservable()
				.Subscribe(_ => {
					//ステータス変化の更新
					foreach(var item in StatusChanges) {
						item.OnUpdateStatus(this);
					}
				})
				.AddTo(this);
		}

		/// <summary>
		/// 生成された瞬間に呼ばれる
		/// </summary>
		/// <param name="asset"></param>
		protected virtual void OnSpawn(CharacterAsset asset) {

		}
	}
}