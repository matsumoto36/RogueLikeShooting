using System;
using System.Threading;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;

namespace DDD.Katano
{
	public class GameInfoScreenView : MonoBehaviour
	{
		public Text Label;
		public CanvasGroup CanvasGroup;

		public void ShowText(string text)
		{
			Label.text = text;
			Label.enabled = true;
		}
		
		public void HideText()
		{
			Label.enabled = false;
			Label.text = string.Empty;
		}
	}
}