using UnityEngine;

namespace DDD.Katano.Model
{
	[CreateAssetMenu(menuName = "Game/Create Floor Settings")]
	public class MazeSettings : ScriptableObject
	{
		public string DungeonName;

		[Header("Room Objects")]
		public GameObject PlayerRoom;
		public GameObject[] EnemyRoom;
		public GameObject BirdsEyeCamera;
	}
}