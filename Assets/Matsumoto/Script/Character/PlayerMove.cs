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

			var input = _playerCore.InputEventProvider;

			//移動
			transform.position += _playerCore.Parameter.MoveSpeed * input.GetMoveVector() * Time.deltaTime;

			//向きの変更
			transform.rotation = Quaternion.LookRotation(input.GetPleyerDirection(transform.position) - transform.position);

		}

	}
}
