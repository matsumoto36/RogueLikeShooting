using System.Threading;
using DG.Tweening;
using Reqweldzen.Extensions;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLike.Katano
{
	public class GameInfoScreenView : MonoBehaviour
	{
		public Text Label;
		public CanvasGroup CanvasGroup;

		public async UniTask ShowFloorText(string floorName, int count, CancellationToken token = default)
		{
			Label.text = $"{floorName}\n{count}F";

			Label.enabled = true;
			await UniTask.Delay(2000, cancellationToken: token);

			Label.enabled = false;
			
			await CanvasGroup.DOFade(0, 0.5f).Play();
		}
	}
}