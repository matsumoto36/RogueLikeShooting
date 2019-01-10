using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace DDD.Katano
{
	public class DebugPlayerCamera : MonoBehaviour
	{
		public Transform Target { get; set; }

		public Vector3 Position;

		private void Start()
		{
			this.LateUpdateAsObservable()
				.Subscribe(_ => FollowTarget());
		}

		private void FollowTarget()
		{
			if (Target == null) return;
			
			transform.position = Target.position + Position;
			transform.LookAt(Target);
		}
	}
}