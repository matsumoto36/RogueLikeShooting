using System.Collections.Generic;
using RogueLike.Katano.View;
using RogueLike.Matsumoto;
using UnityEngine;

namespace RogueLike.Katano
{
	[DisallowMultipleComponent]
	public abstract class RoomComponent : MonoBehaviour
	{
		protected RoomView Owner;
		
		private void Awake()
		{
			Owner = GetComponent<RoomView>();
		}
		
		public abstract void Construct(IEnumerable<CharacterSpawner> spawners);
		public virtual void Initialize() {}
		public virtual void Spawn() {}
	}
}