using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Chikazawa;
using DDD.Chikazawa.InputEventProvider;
using DDD.Katano;
using DDD.Katano.View.Character;
using DDD.Matsumoto.Character;
using DDD.Matsumoto.Character.Asset;
using DDD.Matsumoto.Managers;
using DDD.Matsumoto.UI;
using DDD.Nishiwaki;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace DDD.Matsumoto
{
	/// <summary>
	///     プレイヤーのコアクラス
	/// </summary>
	public class PlayerCore : CharacterCore
	{
		[Inject]
		private Settings _settings;

		private static readonly List<PlayerCore> Players = new List<PlayerCore>();

		[Inject]
		private PlayerHealthProvider _playerHealthProvider;
		public override IReadOnlyReactiveProperty<int> CurrentHealth => _playerHealthProvider.CurrentHealth;
		public override int MaxHealth => _playerHealthProvider.MaxHealth;


		private readonly BoolReactiveProperty _isFreeze = new BoolReactiveProperty();
		/// <summary>
		///     凍結中
		/// </summary>
		public IReadOnlyReactiveProperty<bool> IsFreeze => _isFreeze;
		
		private UIWeaponChange _weaponChangeUI;
		private bool _canChangeWeapon = true;
		private float _changeWeaponTime;

		[Inject]
		private IMessagePublisher _messagePublisher;

		public IWeapon ChangeTargetWeapon { get; private set; }

		public int ID { get; private set; }
		
		public IInputEventProvider InputEventProvider { get; set; }

		protected override void TakeDamage(IAttacker attacker, int value)
		{
			//ダメージ音
			Audio.AudioManager.PlaySE("hitting1");

			_playerHealthProvider.TakeDamage(value);
			if (IsDead.Value) Kill(attacker);
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

			if(isLast) {

				//死亡音
				Audio.AudioManager.PlaySE("destruction1");
				_messagePublisher.Publish(new MazeSignal.PlayerKilled());
			}
		}

		public override void OnSpawn(CharacterAsset asset)
		{
			//レイヤー設定
			gameObject.layer = LayerMask.NameToLayer("Player");
			Alliance = CharacterType.Player;

			//リストに追加
			Players.Add(this);

			var playerAsset = (PlayerAsset) asset;
			//IDの設定
			ID = playerAsset.ID;

			//UIの取得
			_weaponChangeUI = UIManager.Instance.GetUiBase("WeaponChangeUI" + ID) as UIWeaponChange;

			//追加のコンポーネントを追加
			gameObject.AddComponent<PlayerMove>();
			gameObject.AddComponent<PlayerAttack>();
		}

		public override IReadOnlyReactiveProperty<bool> IsDead => _playerHealthProvider.IsDead;

		protected override void Start()
		{
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
		private void WeaponChangeUpdate() {

			void Reset(bool canChange)
			{
				//入れ替えキャンセル
				_changeWeaponTime = 0;
				_canChangeWeapon = canChange;
				ChangeTargetWeapon = null;

				if(!canChange)
					_weaponChangeUI.Hide();

				_weaponChangeUI.SetAmount(0);

			}


			if(ChangeTargetWeapon == null) {
				ChangeTargetWeapon = GetNearestWeapon(_settings.EquipWeaponRange);
			}

			if(ChangeTargetWeapon == null) {
				Reset(false);
				return;
			}

			_weaponChangeUI.Show();
			_weaponChangeUI.SetControllerType(InputEventProvider is InputKeyBoard);
			var screenPos = Camera.main.WorldToScreenPoint(transform.position);
			((RectTransform)(_weaponChangeUI.transform)).anchoredPosition = screenPos;

			//武器切り替え
			if (!InputEventProvider.GetChangeBody())
			{
				Reset(true);
				return;
			}

			if(!_canChangeWeapon) return;

			if(_changeWeaponTime == 0) {
				//入れ替え開始
				Audio.AudioManager.PlaySE("cursor3");
			}

			_changeWeaponTime += Time.deltaTime;
			_weaponChangeUI.SetAmount(_changeWeaponTime / _settings.ChangeWeaponWait);
			if (!(_changeWeaponTime > _settings.ChangeWeaponWait)) return;
			//入れ替え完了
			CharacterArm.Attach(ChangeTargetWeapon);
			Reset(false);

			//入れ替え完了音
			Audio.AudioManager.PlaySE("arm-action1");
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
		}

		[Serializable]
		public class Settings
		{
			/// <summary>
			///     武器切り替え許容範囲
			/// </summary>
			public float EquipWeaponRange = 1;

			/// <summary>
			///     武器を切り替える所要時間
			/// </summary>
			public float ChangeWeaponWait = 3;
		}
	}
}