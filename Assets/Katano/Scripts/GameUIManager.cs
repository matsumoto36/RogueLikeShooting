using System.Threading;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano
{
	/// <summary>
	/// UIマネージャ
	/// </summary>
	public class GameUIManager : MonoBehaviour
	{
		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize()
		{
			Log("Initialized.");
		}
		
		/// <summary>
		/// フェードアウト
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public UniTask FadeOutAsync(CancellationToken token = default)
		{
			// TODO: FadeOut Process
			return UniTask.Delay(1000, cancellationToken: token).ContinueWith(() => Log("FadeOut."));
		}

		/// <summary>
		/// フェードイン
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public UniTask FadeInAsync(CancellationToken token = default)
		{
			// TODO: FadeIn Process
			return UniTask.Delay(1000, cancellationToken: token).ContinueWith(() => Log("FadeIn."));
		}
		
		private static void Log(string log)
		{
			Debug.Log($"[UIManager] {log}");
		}
	}
}