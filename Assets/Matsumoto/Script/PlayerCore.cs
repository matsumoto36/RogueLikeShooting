using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using RogueLike.Matsumoto.Character;
using RogueLike.Matsumoto.Character.Asset;
using RogueLike.Chikazawa;

namespace RogueLike.Matsumoto {

	/// <summary>
	/// プレイヤーのコアクラス
	/// </summary>
	public class PlayerCore : CharacterCore {

		public Subject<PlayerCore> PlayerUpdate = new Subject<PlayerCore>();

		static List<PlayerCore> _players = new List<PlayerCore>();
		static PlayerHPProvider _playerHPProvider = null;

		public int ID { get; private set; }
		public IInputEventProvider InputEventProvider { get; private set; }

		public override int HP {
			get {
				return _playerHPProvider.HP;
			}
			protected set {
				_playerHPProvider.HP = value;
			}
		}

		public override void Kill(IAttacker attacker) {
			base.Kill(attacker);

			//リストから削除
			_players.Remove(this);

			//他も殺す
			if(_players.Count > 0)
				_players[0].Kill(attacker);
		}

		protected override void OnSpawn(CharacterAsset asset) {

			var playerAsset = (PlayerAsset)asset;

			//リストに追加
			_players.Add(this);

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

			InputEventProvider = new Chikazawa.InputEventProvider.InputKeyBoard();

			this.UpdateAsObservable()
				.Subscribe(_ => PlayerUpdate.OnNext(this))
				.AddTo(this);
		}

	}
}