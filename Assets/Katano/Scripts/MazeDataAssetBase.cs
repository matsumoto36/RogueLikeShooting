using UnityEngine;

namespace RougeLike.Katano.Maze
{
	[CreateAssetMenu(fileName = "MazeDataAsset", menuName = "Maze/Create Maze Asset")]
	public class MazeDataAssetBase : ScriptableObject
	{
		public GameObject[] RoomPrefabList;

		public GameObject[] AislePrefabList;
	}
}