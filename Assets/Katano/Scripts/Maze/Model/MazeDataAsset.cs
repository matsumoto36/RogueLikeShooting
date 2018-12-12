using UnityEngine;

namespace RogueLike.Katano.Maze
{
	[CreateAssetMenu(fileName = "MazeDataAsset", menuName = "Maze/Create Maze Asset")]
	public class MazeDataAsset : ScriptableObject
	{
		public GameObject PlayerRoomPrefab;
		public GameObject[] RoomPrefabList;
		public GameObject[] AislePrefabList;
		public GameObject CameraAnchor;
	}
}