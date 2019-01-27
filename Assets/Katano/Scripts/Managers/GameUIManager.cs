using System.Diagnostics;
using System.Threading;
using DDD.Katano.Installers;
using DG.Tweening;
using Reqweldzen.Extensions;
using UniRx;
using UniRx.Async;
using UnityEngine;
using Zenject;
using Debug = UnityEngine.Debug;

namespace DDD.Katano.Managers
{
	/// <inheritdoc />
	/// <summary>
	/// UIマネージャ
	/// </summary>
	public class GameUIManager : MonoBehaviour
	{
		[Inject]
		private IMessageReceiver _messageReceiver;

		[Inject]
		private MazeSettings _mazeSettings;

		public GameInfoScreenView InfoScreenView;
		
		/// <summary>
		/// フェードアウト
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public UniTask FadeOutAsync(CancellationToken token = default)
		{
			async UniTask FadeOut()
			{
				Log("Start FadeOut.");

				await InfoScreenView.CanvasGroup.DOFade(1, 1).Play();
				
				Log("End FadeOut.");
			}
			
			// TODO: FadeOut Process
			return FadeOut();
		}

		/// <summary>
		/// ゲームオーバーフェードアウト
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public UniTask GameOverFadeOutAsync(CancellationToken token = default)
		{
			async UniTask FadeOut()
			{
				InfoScreenView.ShowText("あなたはやられてしまった");
				
				await InfoScreenView.CanvasGroup.DOFade(1, 3).Play();

				await UniTask.Delay(1000, cancellationToken: token);
				
				InfoScreenView.HideText();
			}

			return FadeOut();
		}

		/// <summary>
		/// フェードイン
		/// </summary>
		/// <param name="count"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		public UniTask FadeInAsync(int count, CancellationToken token = default)
		{
			async UniTask FadeIn()
			{
				Log("Start FadeIn.");

				InfoScreenView.ShowText($"{_mazeSettings.DungeonName}\n{count}F");
				
				await UniTask.Delay(2000, cancellationToken: token);
				InfoScreenView.HideText();
				
				await InfoScreenView.CanvasGroup.DOFade(0, 0.5f).Play();
				
				Log("End FadeIn.");
			}
			
			// TODO: FadeIn Process
			return FadeIn();
		}
		
		[Conditional("UNITY_EDITOR")]
		private static void Log(string log)
		{
			Debug.Log($"[UIManager] {log}");
		}
	}
}