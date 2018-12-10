using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using RogueLike.Matsumoto.Character;
using RogueLike.Matsumoto.Character.Asset;
using RogueLike.Chikazawa;
using RogueLike.Matsumoto.Managers;
using RogueLike.Nishiwaki;
using Unity.Linq;
using UnityEngine.SceneManagement;

namespace RogueLike.Matsumoto {

	/// <summary>
	/// プレイヤーのコアクラス
	/// </summary>
	public class PlayerCore : CharacterCore {

		private const float EquipWeaponRange = 5;
		private static readonly List<PlayerCore> Players = new List<PlayerCore>();

		public Subject<PlayerCore> PlayerUpdate = new Subject<PlayerCore>();

		private static PlayerHPProvider _playerHPProvider;

		public int ID { get; private set; }
		public IInputEventProvider InputEventProvider { get; set; }
		public bool IsFreeze { get; set; }

		public override int HP {
			get => _playerHPProvider.HP;
			protected set => _playerHPProvider.HP = value;
		}

		public override void Kill(IAttacker attacker) {
			base.Kill(attacker);

			//リストから削除
			Players.Remove(this);

			//他も殺す
			if(Players.Count > 0)
				Players[0].Kill(attacker);
		}

		protected override void OnSpawn(CharacterAsset asset) {

			CharacterType = CharacterType.Player;

			var playerAsset = (PlayerAsset)asset;

			//リストに追加
			Players.Add(this);

			//IDの設定
			ID = playerAsset.ID;

			//HPの設定
			if(!_playerHPProvider) {
				if(!(_playerHPProvider = FindObjectOfType<PlayerHPProvider>())) {
					_playerHPProvider = new GameObject("[PlayerHPProvider]")
						.AddComponent<PlayerHPProvider>();

					_playerHPProvider.HP = playerAsset.HP;
				}
			}

			//追加のコンポーネントを追加
			gameObject.AddComponent<PlayerMove>();
			gameObject.AddComponent<PlayerAttack>();
		}

		protected override void Start() {
			base.Start();

			if(InputEventProvider == null)
				InputEventProvider = new Chikazawa.InputEventProvider.InputKeyBoard();

			this.UpdateAsObservable()
				.Where(_ => !IsFreeze)
				.Subscribe(_ => PlayerUpdate.OnNext(this))
				.AddTo(this);
		}

		/// <summary>
		/// プレイヤーをIDから取得する
		/// </summary>
		/// <returns></returns>
		public static PlayerCore GetPlayerFromID(int id) {
			return Players
				.Find(item => item.ID == id);
		}

		/// <summary>
		/// TODO プレイヤーから一番近い取り付けられる武器を取得
		/// </summary>
		/// <returns></returns>
		private Nishiwaki.IWeapon GetNearestWeapon() {

			//return FindObjectsOfType<Component>()
			//	//キャスト
			//	.OfType<Nishiwaki.IWeapon>()
			//	//オーナーがいない = 取り付けられる (予定)
			//	//.Where(item => !item.GetOwner())
			//	//距離で並べ替える
			//	.OrderBy(item => (item.GetBody().transform.position - transform.position).sqrMagnitude)
			//	//一番近いやつを返す
			//	.FirstOrDefault();

			return GameInstance.AttachableWeaponList
				//距離で並べ替える
				.OrderBy(item => (item.GetBody().transform.position - transform.position).sqrMagnitude)
				//一番近いやつを返す
				.FirstOrDefault();

		}

	}
}