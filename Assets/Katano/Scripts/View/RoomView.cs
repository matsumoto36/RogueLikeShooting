using System.Collections.Generic;
using RogueLike.Katano.Maze;
using RogueLike.Katano.View.Components;
using RogueLike.Matsumoto;
using Unity.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace RogueLike.Katano.View
{
	/// <summary>
	/// 部屋のViewオブジェクト
	/// </summary>
	public class RoomView : MonoBehaviour
	{
		public IEnumerable<CharacterSpawner> CharacterSpawners { get; private set; }

		[SerializeField]
		private NavMeshSurface _navMeshSurface;
		
		public Room Room { get; private set; }

		private void Awake()
		{
			CharacterSpawners = gameObject.Children().OfComponent<CharacterSpawner>();
		}

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="room"></param>
		public void Construct(Room room)
		{
			Room = room;

			var components = gameObject.Children().OfComponent<RoomComponent>();
			foreach (var component in components)
			{
				component.OnInitialize();
			}
		}

		public void Enter(IEnumerable<PlayerCore> players)
		{
			foreach (var player in players)
			{
				player.transform.SetParent(transform);
			}
		}
	}
}