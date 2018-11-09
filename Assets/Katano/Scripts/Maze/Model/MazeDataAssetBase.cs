using UnityEngine;

namespace RogueLike.Katano.Maze
{
	[CreateAssetMenu(fileName = "MazeDataAsset", menuName = "Maze/Create Maze Asset")]
	public class MazeDataAssetBase : ScriptableObject
	{
		public GameObject PlayerRoomPrefab;
		public GameObject[] RoomPrefabList;
		public GameObject[] AislePrefabList;
	}
}