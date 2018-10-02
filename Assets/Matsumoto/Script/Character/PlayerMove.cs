using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace RogueLike.Matsumoto.Character {

	[RequireComponent(typeof(PlayerCore))]
	public class PlayerMove : MonoBehaviour {

		PlayerCore _playerCore;

		void Start() {
			_playerCore = GetComponent<PlayerCore>();
		}

		public void Update() {

			var vec = new Vector3(
				Input.GetAxisRaw("Horizontal"),
				0,
				Input.GetAxisRaw("Vertical"))
				.normalized;

			transform.position += _playerCore.Parameter.MoveSpeed * vec * Time.deltaTime;

		}

	}
}
