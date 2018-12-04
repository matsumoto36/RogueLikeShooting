using UnityEngine;

namespace RogueLike.Katano.Model
{
	[CreateAssetMenu(fileName = "FloorSettings", menuName = "Maze/Create Floor Settings")]
	public class MazeFloorSettings : ScriptableObject
	{
		public int Width;
		public int Height;
	}
}