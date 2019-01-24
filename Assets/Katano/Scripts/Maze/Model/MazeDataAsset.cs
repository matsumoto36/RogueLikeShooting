using System;
using UnityEngine;

namespace DDD.Katano.Maze
{
	[CreateAssetMenu(fileName = "MazeDataAsset", menuName = "Maze/Create Maze Asset")]
	public class MazeDataAsset : ScriptableObject
	{
		public GameObject PlayerRoomPrefab;
		public GameObject[] RoomPrefabList;
		public GameObject CameraAnchor;
	}
}