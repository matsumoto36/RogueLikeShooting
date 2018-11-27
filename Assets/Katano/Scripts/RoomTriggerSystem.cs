using System.Collections.Generic;
using RogueLike.Matsumoto;
using UnityEngine;

namespace RogueLike.Katano
{
	[DisallowMultipleComponent]
	public abstract class RoomTriggerSystem : MonoBehaviour
	{
		public abstract void Construct(IEnumerable<CharacterSpawner> spawners);
		public virtual void Initialize() {}
		public virtual void Spawn() {}
	}
}