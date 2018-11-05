using System.Linq;
using Reqweldzen.Extensions;
using RogueLike.Katano.Maze.View;
using RogueLike.Matsumoto;
using UnityEngine;

namespace RogueLike.Katano.Maze
{
	public class MazeCharacterSpawner : MonoBehaviour
	{
		public CharacterSpawner CharacterSpawner;
		public DebugPlayerCamera DebugPlayerCamera;

		public void Spawn(MazeViewer mazeViewer)
		{
			var character = CharacterSpawner.Spawn();

			var spawnRoom = mazeViewer.Maze.RoomList.OfType<Room>().RandomAt(x => x.IsEnable);
			character.transform.position = mazeViewer.Rooms[spawnRoom.Id].transform.position;
			
			DebugPlayerCamera.Target = character.transform;
		}
	}
}