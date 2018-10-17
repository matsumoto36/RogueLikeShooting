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


		public IInputEventProvider InputEventProvider { get; private set; }


		protected override void OnSpawn(CharacterAsset asset) {
			//追加のコンポーネントを追加
			gameObject.AddComponent<PlayerMove>();
			gameObject.AddComponent<PlayerAttack>();
		}

		void Start() {
			InputEventProvider = new Chikazawa.InputEventProvider.InputKeyBoard();

			this.UpdateAsObservable()
				.Subscribe(_ => PlayerUpdate.OnNext(this))
				.AddTo(this);
		}

	}
}