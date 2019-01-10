using System.Threading;
using DG.Tweening;
using Reqweldzen.Extensions;
using UniRx.Async;
using UnityEngine;

namespace DDD.Katano.Managers
{
	public class GameTitleUIManager : MonoBehaviour
	{
		public CanvasGroup TitleScreen;
		
		/// <summary>
		/// フェードイン
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public UniTask TitleFadeInAsync(CancellationToken token = default)
		{
			async UniTask FadeIn()
			{
				Log("Start FadeIn.");
				
				await TitleScreen.DOFade(1, 1).Play();
				
				Log("End FadeIn.");
			}
			
			// TODO: FadeIn Process
			return FadeIn();
		}
		
		public UniTask TitleFadeOutAsync(CancellationToken token = default)
		{
			async UniTask FadeOut()
			{
				Log("Start FadeOut.");

				await TitleScreen.DOFade(0, 1).Play();
				
				Log("End FadeOut.");
			}
			
			// TODO: FadeOut Process
			return FadeOut();
		}
		
		private static void Log(string log)
		{
			Debug.Log($"[UIManager] {log}");
		}
	}
}