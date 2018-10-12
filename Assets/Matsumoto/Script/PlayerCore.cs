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

		protected override void Init(CharacterAsset asset) {
			
		}

		void Start() {
			InputEventProvider = new Chikazawa.InputEventProvider.PlayerInputProvider();
		}

		void Update() {

		}

	}
}