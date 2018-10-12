using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RogueLike.Matsumoto.Character;
using RogueLike.Chikazawa;


namespace RogueLike.Matsumoto {

	/// <summary>
	/// プレイヤーのコアクラス
	/// </summary>
	public class PlayerCore : CharacterCore {

		public IInputEventProvider InputEventProvider { get; private set; }

		protected override void CreateEx(CharacterAsset asset) {
			//追加のコンポーネントを追加
			gameObject.AddComponent<PlayerMove>();
			gameObject.AddComponent<PlayerAttack>();
		}

		void Start() {
			InputEventProvider = new Chikazawa.InputEventProvider.InputKeyBoard();

		}

		void Update() {

		}

	}
}