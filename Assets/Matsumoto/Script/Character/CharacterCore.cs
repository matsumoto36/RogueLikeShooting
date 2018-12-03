using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using RogueLike.Matsumoto.Character.Asset;
using RogueLike.Matsumoto.Attack;
using RogueLike.Nishiwaki;

namespace RogueLike.Matsumoto.Character {

	/// <summary>
	/// 各キャラクターのコアクラス
	/// </summary>
	public abstract class CharacterCore : MonoBehaviour {

		public List<IStatusChange> StatusChanges {
			get; protected set;
		} = new List<IStatusChange>();

		public IWeapon Weapon { get; private set; }

		public abstract int HP {
			get; protected set;
		}

		/// <summary>
		/// 武器を装備する
		/// </summary>
		/// <param name="weapon"></param>
		public void AttachWeapon(IWeapon weapon) {
			Weapon = weapon;
		}

		/// <summary>
		/// 武器を外す
		/// </summary>
		public void DetachWeapon() {
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
					message = !cAttacker.Attacker ? "Unknown" : cAttacker.Attacker.name;
					break;
				default:
					message = "Unknown";
					break;
			}

			Debug.Log($"{name}は{message}に倒された!");

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
			var obj = Instantiate(asset.ModelPrefab, spawnTransform.position, spawnTransform.rotation);
			var chara = obj.AddComponent<T>();
			chara.OnSpawn(asset);

			return chara;
		}

		protected virtual void Start() {

			this.UpdateAsObservable()
				.Subscribe(_ => {

					//ステータス変化の更新
					for(int i = 0;i < StatusChanges.Count;i++) {
						StatusChanges[i].OnUpdateStatus(this);
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