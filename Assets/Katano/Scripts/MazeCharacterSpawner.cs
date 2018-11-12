using System.Linq;
using Reqweldzen.Extensions;
using RogueLike.Katano.Maze.View;
using RogueLike.Matsumoto;
using UnityEngine;

namespace RogueLike.Katano.Maze
{
	public class MazeCharacterSpawner : MonoBehaviour
	{
		private MazeView _mazeView;

		public void Initialize(MazeView mazeView)
		{
			_mazeView = mazeView;
		}
		
		public void Spawn(CharacterSpawner spawner)
		{
			var character = spawner.Spawn();

			var spawnRoom = _mazeView.Maze.RoomList.OfType<Room>().RandomAt(x => x.IsEnable);
			character.transform.position = _mazeView.Rooms[spawnRoom.Id].transform.position;
		}

	}
}