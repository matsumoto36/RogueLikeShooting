using DG.Tweening;
using Reqweldzen.Extensions;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano.Managers
{
	public class GameResultUIManager : MonoBehaviour
	{
		public GameResultScreenView ResultScreenView;
		
		
		public UniTask ScreenFadeIn()
		{
			async UniTask FadeIn()
			{
				await ResultScreenView.CanvasGroup.DOFade(1, 1).Play();
			}

			return FadeIn();
		}

		public UniTask ScreenFadeOut()
		{
			async UniTask FadeOut()
			{
				await ResultScreenView.CanvasGroup.DOFade(0, 1).Play();
			}

			return FadeOut();
		}
		
		public void ShowText(string text)
		{
			ResultScreenView.Label.text = text;
		}
	}
}