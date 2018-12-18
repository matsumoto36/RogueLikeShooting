using System.Threading;
using DG.Tweening;
using Reqweldzen.Extensions;
using UniRx;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano.Managers
{
	/// <summary>
	/// UIマネージャ
	/// </summary>
	public class GameUIManager : MonoBehaviour
	{
		private IMessageReceiver _messageReceiver;

		public GameInfoScreenView InfoScreenView;
		
		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize(IMessageReceiver messageReceiver)
		{
			_messageReceiver = messageReceiver;
			
			Log("Initialized.");
		}
		
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
		/// <param name="token"></param>
		/// <returns></returns>
		public UniTask FadeInAsync(int count, CancellationToken token = default)
		{
			async UniTask FadeIn()
			{
				Log("Start FadeIn.");

				InfoScreenView.ShowText($"ダンジョン\n{count}F");
				
				await UniTask.Delay(2000, cancellationToken: token);
				InfoScreenView.HideText();
				
				await InfoScreenView.CanvasGroup.DOFade(0, 0.5f).Play();
				
				Log("End FadeIn.");
			}
			
			// TODO: FadeIn Process
			return FadeIn();
		}
		
		private static void Log(string log)
		{
			Debug.Log($"[UIManager] {log}");
		}
	}
}