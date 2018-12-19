using UnityEngine;

namespace RogueLike.Katano.Model
{
	[CreateAssetMenu(menuName = "Game/Create Result Data", fileName = "GameResultData")]
	public class GameResultData : ScriptableObject
	{
		public int Score;
		public float ClearTime;
	}
}