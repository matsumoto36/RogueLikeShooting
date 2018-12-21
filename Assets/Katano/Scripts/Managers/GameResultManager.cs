using System;
using System.Linq;
using DDD.Chikazawa;
using DDD.Katano.Model;
using DDD.Takahashi;
using GamepadInput;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DDD.Katano.Managers
{
	/// <summary>
	/// リザルトシーンマネージャ
	/// </summary>
	public class GameResultManager : MonoBehaviour
	{
		public GameSettings GameSettings;
		public PlayerBindData BindData;
		public GameResultData ResultData;
		public GameResultUIManager UIManager;

		public GameObject[] PlayerObjects;

		private void Start()
		{
			for (var i = 0; i < 4; i++)
			{
				if (BindData.PlayerEntries[i] != ControllerIndex.Invalid)
				{
					PlayerObjects[i].gameObject.SetActive(true);
				}
			}
			
			ResultCoroutine().Forget();
		}

		private async UniTaskVoid ResultCoroutine()
		{
			
			
			UIManager.ShowText(ResultData.IsClear
				? $"アナタハ{ResultData.ReachedFloor}階層ニ到達シタ\nアナタノ冒険ハツヅク"
				: $"アナタハ{ResultData.ReachedFloor}階層デ\nチカラツキタ");

			await UIManager.ScreenFadeIn();

			if (!ResultData.IsClear)
			foreach (var player in PlayerObjects.Where(x => x.gameObject.activeSelf))
			{
				player.GetComponentInChildren<DissolveShaderControl>().Hide();
			}
			
			await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Return) ||
			                              GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any));

			foreach (var player in PlayerObjects)
			{
				player.GetComponentInChildren<DissolveShaderControl>().Hide();
			}
			
			await UIManager.ScreenFadeOut();

			SceneManager.LoadScene(GameSettings.ResultSettings.TitleScene.ToString());
		}

		[Serializable]
		public class Settings
		{
			public GameScenes TitleScene;
		}
	}
}