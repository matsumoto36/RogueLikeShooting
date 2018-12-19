using RogueLike.Katano.Managers;
using UnityEngine;

namespace RogueLike.Katano
{
	/// <summary>
	/// ゲーム設定
	/// </summary>
	// [CreateAssetMenu(menuName = "Game/Create Settings", fileName = "GameSettings")]
	public class GameSettings : ScriptableObject
	{
		/// <summary>
		/// タイトルシーン設定
		/// </summary>
		public GameTitleManager.Settings TitleSettings;
		/// <summary>
		/// ゲームシーン設定
		/// </summary>
		public MainGameManager.Settings MainGameSettings;
	}
}