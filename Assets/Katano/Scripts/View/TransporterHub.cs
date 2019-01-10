using UnityEngine;

namespace DDD.Katano.View
{
	/// <summary>
	/// 転送システムハブ
	/// </summary>
	public class TransporterHub : MonoBehaviour
	{
		public TransporterView North;
		public TransporterView East;
		public TransporterView South;
		public TransporterView West;
	}
}