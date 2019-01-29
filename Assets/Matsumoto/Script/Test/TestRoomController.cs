using UnityEngine;
using System.Collections;

namespace DDD.Matsumoto.Test {

	public class TestRoomController : MonoBehaviour {

		public Camera MainCamera;
		public Transform CameraAnchor;

		// Use this for initialization
		void Start() {

			MainCamera.transform
				.SetPositionAndRotation(CameraAnchor.position, CameraAnchor.rotation);
		}

		// Update is called once per frame
		void Update() {

		}
	}

}