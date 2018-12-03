using UnityEngine;

namespace RogueLike.Katano.View.Components
{
	[DisallowMultipleComponent]
	public abstract class RoomComponent : MonoBehaviour
	{
		protected RoomView Owner;
		
		private void Awake()
		{
			Owner = GetComponent<RoomView>();
		}
		
		public abstract void OnInitialize();
		public virtual void Initialize() {}
		public virtual void Spawn() {}
	}
}