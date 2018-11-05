using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using RogueLike.Matsumoto.Character;
using RogueLike.Chikazawa;

namespace RogueLike.Matsumoto {

	/// <summary>
	/// プレイヤーのコアクラス
	/// </summary>
	public class PlayerCore : CharacterCore {

		public Subject<PlayerCore> PlayerUpdate = new Subject<PlayerCore>();

		static PlayerHPProvider playerHPProvider = null;

		public IInputEventProvider InputEventProvider { get; private set; }

		public override int HP {
			get {
				return playerHPProvider.HP;
			}
			protected set {
				playerHPProvider.HP = value;
			}
		}

		protected override void OnSpawn(CharacterAsset asset) {

			//HPの設定
			if(!playerHPProvider) {
				if(!(playerHPProvider = FindObjectOfType<PlayerHPProvider>())) {
					playerHPProvider = new GameObject("[PlayerHPProvider]")
						.AddComponent<PlayerHPProvider>();

					playerHPProvider.HP = asset.HP;
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