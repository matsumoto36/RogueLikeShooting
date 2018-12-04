using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace RogueLike.Matsumoto.Character {

	[RequireComponent(typeof(PlayerCore))]
	public class PlayerMove : MonoBehaviour {

		void Start() {

			GetComponent<PlayerCore>().PlayerUpdate
				.Subscribe(player => {

					var input = player.InputEventProvider;

//					//移動(武器依存で移動したい)
//					transform.position += player.Parameter.MoveSpeed * input.GetMoveVector() * Time.deltaTime;
//
//					//向きの変更
//					transform.rotation = Quaternion.LookRotation(input.GetPleyerDirection(transform.position) - transform.position);
				})
				.AddTo(this);
		}
	}
}
