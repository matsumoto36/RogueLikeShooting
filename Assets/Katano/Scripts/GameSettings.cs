using UnityEngine;

namespace RogueLike.Katano
{
	// [CreateAssetMenu(menuName = "Game/Create Settings", fileName = "GameSettings")]
	public class GameSettings : ScriptableObject
	{
		public GameTitleManager.Settings TitleSettings;
	}
}