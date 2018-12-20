using System;
using System.Collections.Generic;
using System.Linq;
using RogueLike.Chikazawa;
using RogueLike.Chikazawa.InputEventProvider;
using RogueLike.Katano;
using RogueLike.Katano.Managers;
using RogueLike.Matsumoto.Character;
using RogueLike.Matsumoto.Character.Asset;
using RogueLike.Matsumoto.Managers;
using RogueLike.Nishiwaki;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace RogueLike.Matsumoto
{
	/// <summary>
	///     プレイヤーのコアクラス
	/// </summary>
	public class PlayerCore : CharacterCore
	{
		/// <summary>
		/// 武器切り替え許容範囲
		/// </summary>
		private const float EquipWeaponRange = 5;
		
		/// <summary>
		/// 武器を切り替える所要時間
		/// </summary>
		private const float ChangeWeaponWait = 3;
		private static readonly List<PlayerCore> Players = new List<PlayerCore>();

		private static PlayerHPProvider _playerHPProvider;
		private bool _canChangeWeapon = true;
		private float _changeWeaponTime;

//		[NonSerialized]
//		public Subject<PlayerCore> PlayerUpdate = new Subject<PlayerCore>();

		public IWeapon ChangeTargetWeapon { get; private set; }

		public int ID { get; private set; }
		public IInputEventProvider InputEventProvider { get; set; }
		// public bool IsFreeze { get; set; }

		private readonly BoolReactiveProperty _isFreeze = new BoolReactiveProperty();
		/// <summary>
		/// 凍結中
		/// </summary>
		public IReadOnlyReactiveProperty<bool> IsFreeze => _isFreeze;
		
		/// <summary>
		/// メインゲームマネージャ
		/// </summary>
		public MainGameManager MainGameManager { get; set; }

		public override int HP
		{
			get => _playerHPProvider.NowHP;
			protected set => _playerHPProvider.NowHP = value;
		}

		public override void Kill(IAttacker attacker)
		{
			base.Kill(attacker);

			var isLast = Players.Count == 1 && Players[0] == this;

			//リストから削除
			Players.Remove(this);

			//他も殺す
			if (Players.Count > 0)
				Players[0].Kill(attacker);

			if (isLast) MainGameManager.EventPublish(new MazeSignal.PlayerKilled());
		}

		protected override void OnSpawn(CharacterAsset asset)
		{
			CharacterType = CharacterType.Player;

			var playerAsset = (PlayerAsset) asset;

			//リストに追加
			Players.Add(this);

			//IDの設定
			ID = playerAsset.ID;

			//HPの設定
			if (!_playerHPProvider)
				if (!(_playerHPProvider = FindObjectOfType<PlayerHPProvider>()))
				{
					_playerHPProvider = new GameObject("[PlayerHPProvider]")
						.AddComponent<PlayerHPProvider>();

					_playerHPProvider.MaxHP
						= _playerHPProvider.NowHP
							= playerAsset.HP;

					//暫定的にプレイヤーが出す
					UIManager.Instance.Show("PlayerStatus");
				}

			//追加のコンポーネントを追加
			gameObject.AddComponent<PlayerMove>();
			gameObject.AddComponent<PlayerAttack>();
		}

		protected override void Start()
		{
			base.Start();

			// デバッグ用
			if (InputEventProvider == null)
				InputEventProvider = new InputKeyBoard();

			this.UpdateAsObservable()
				.Where(_ => !IsFreeze.Value)
				.Subscribe(_ =>
				{
					//武器チェンジの更新
					WeaponChangeUpdate();
				})
				.AddTo(this);
		}

		/// <summary>
		///     武器チェンジのボタン処理を行う
		/// </summary>
		private void WeaponChangeUpdate()
		{
			void Reset(bool canChange)
			{
				_changeWeaponTime = 0;
				_canChangeWeapon = canChange;
				ChangeTargetWeapon = null;
			}

			//武器切り替え
			if (!InputEventProvider.GetChangeBody())
			{
				Reset(true);
				return;
			}

			if (!_canChangeWeapon) return;

			if (ChangeTargetWeapon == null)
				ChangeTargetWeapon = GetNearestWeapon(EquipWeaponRange);

			if (ChangeTargetWeapon == null)
			{
				Reset(false);
				return;
			}

			_changeWeaponTime += Time.deltaTime;
			if (!(_changeWeaponTime > ChangeWeaponWait)) return;
			AttachWeapon(ChangeTargetWeapon);
			Reset(false);
		}

		/// <summary>
		///     プレイヤーをIDから取得する
		/// </summary>
		/// <returns></returns>
		public static PlayerCore GetPlayerFromID(int id)
		{
			return Players
				.Find(item => item.ID == id);
		}

		public void SetFreezeMode(bool isFreeze)
		{
			_isFreeze.Value = isFreeze;
		}


		/// <summary>
		///     プレイヤーから一番近い取り付けられる武器を取得
		/// </summary>
		/// <param name="range"></param>
		/// <returns></returns>
		private IWeapon GetNearestWeapon(float range)
		{
			//下記の内容が実装されるまで使う
			return FindObjectsOfType<Component>()
				//キャスト
				.OfType<IWeapon>()
				//オーナーがいない = 取り付けられる (予定)
				.Where(item => !item.GetOwner())
				.Select(item => (item, (item.GetBody().transform.position - transform.position).sqrMagnitude))
				//一定距離以下のみ抽出
				.Where(item => item.Item2 <= range * range)
				//距離で並べ替える
				.OrderBy(item => item.Item2)
				//一番近いやつを返す
				.Select(item => item.Item1)
				.FirstOrDefault();

			//return GameInstance.AttachableWeaponList
			//	//距離で並べ替える
			//	.OrderBy(item => (item.GetBody().transform.position - transform.position).sqrMagnitude)
			//	//一番近いやつを返す
			//	.FirstOrDefault();
		}
	}
}