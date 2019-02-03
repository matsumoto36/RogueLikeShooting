using System;
using System.Collections.Generic;
using DDD.Chikazawa;
using DDD.Katano.Model;
using DDD.Matsumoto.Audio;
using DDD.Takahashi;
using GamepadInput;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DDD.Katano.Managers
{
	/// <summary>
	///     リザルトシーンマネージャ
	/// </summary>
	public class GameResultManager : MonoBehaviour
	{
		private readonly List<DissolveShaderControl> _playerShaders = new List<DissolveShaderControl>();

		[Inject]
		private GameResultData _resultData;

		[Inject]
		private Settings _settings;

		[Inject]
		private PlayerBindData _bindData;

		public GameObject[] PlayerObjects;
		public GameResultUIManager UIManager;

		private void Start()
		{
			AudioManager.FadeIn(0.5f, "bgm_maoudamashii_cyber42");
			
			for (var i = 0; i < 4; i++)
				if (_bindData.PlayerEntries[i] != ControllerIndex.Invalid)
				{
					PlayerObjects[i].gameObject.SetActive(true);
					_playerShaders.Add(PlayerObjects[i].GetComponentInChildren<DissolveShaderControl>());
				}

			ResultCoroutine().Forget();
		}

		private async UniTaskVoid ResultCoroutine()
		{
			UIManager.ShowText(_resultData.IsClear
				? $"アナタハ{_resultData.ReachedFloor}階層ニ到達シタ\nアナタノ冒険ハツヅク"
				: $"アナタハ{_resultData.ReachedFloor}階層デ\nチカラツキタ");

			await UIManager.ScreenFadeIn();

			if (!_resultData.IsClear)
				foreach (var shader in _playerShaders)
					shader.Hide();

			while (true)
			{
				var isFinished = false;
				for (var i = 0; i < _playerShaders.Count; i++) isFinished |= _playerShaders[i].IsActive;

				if (!isFinished) break;

				await UniTask.Yield();
			}

			UIManager.ResultScreenView.Continue.alpha = 1;

			await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Return) ||
			                              GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any));

			foreach (var shader in _playerShaders) shader.Hide();

			while (true)
			{
				var isFinished = false;
				for (var i = 0; i < _playerShaders.Count; i++) isFinished |= _playerShaders[i].IsActive;

				if (!isFinished) break;

				await UniTask.Yield();
			}

			AudioManager.FadeOut(1.0f);
			
			await UIManager.ScreenFadeOut();

			SceneManager.LoadScene(_settings.TitleScene.ToString());
		}

		[Serializable]
		public class Settings
		{
			public GameScenes TitleScene;
		}
	}
}