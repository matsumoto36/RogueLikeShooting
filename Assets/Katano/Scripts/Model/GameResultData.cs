using UnityEngine;

namespace DDD.Katano.Model
{
	[CreateAssetMenu(menuName = "Game/Create Result Data", fileName = "GameResultData")]
	public class GameResultData : ScriptableObject
	{
		public bool IsClear;
		public int ReachedFloor;
		public int Score;
		public float ClearTime;
	}
}