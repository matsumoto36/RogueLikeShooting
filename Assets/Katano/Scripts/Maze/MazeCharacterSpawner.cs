using System.Linq;
using Reqweldzen.Extensions;
using RogueLike.Katano.Maze.View;
using RogueLike.Matsumoto;
using UnityEngine;

namespace RogueLike.Katano.Maze
{
	public class MazeCharacterSpawner : MonoBehaviour
	{
		private MazeViewer _mazeViewer;

		public void Initialize(MazeViewer mazeViewer)
		{
			_mazeViewer = mazeViewer;
		}
		
		public void Spawn(CharacterSpawner spawner)
		{
			var character = spawner.Spawn();

			var spawnRoom = _mazeViewer.Maze.RoomList.OfType<Room>().RandomAt(x => x.IsEnable);
			character.transform.position = _mazeViewer.Rooms[spawnRoom.Id].transform.position;
		}

		public void Spawn(EnemyGroup enemyGroup)
		{
			foreach (var spawner in enemyGroup.SpawnerList)
			{
				var character = spawner.Spawn();
			}
		}

		public struct EnemyGroup
		{
			public readonly CharacterSpawner[] SpawnerList;

			public EnemyGroup(CharacterSpawner[] spawnerList)
			{
				SpawnerList = spawnerList;
			}
		}
	}
}