using UnityEngine;
using UnityEditor;

namespace DDD.Matsumoto.Character.EnemyAI {

	/// <summary>
	/// AIのパラメーター
	/// </summary>
	[System.Serializable]
	public struct EnemyAIParameter {

		public float CheckTimer;
		public float AngularSpeed;
		public float MoveStartRadius;
		public float MoveStartDifference;
		public float ViewRadius;
		public float ViewAngle;

		public float KeepRange;

	}

}
