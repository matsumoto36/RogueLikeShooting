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
			var vec = input.GetPleyerDirection(transform.position);
			Debug.Log(vec);
			var angle = Vector2.SignedAngle(new Vector2(1, 0), new Vector2(vec.x, vec.z));
			transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, -1, 0));

		}

	}
}
