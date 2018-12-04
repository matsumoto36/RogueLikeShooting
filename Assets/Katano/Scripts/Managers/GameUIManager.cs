using System.Threading;
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
				
				await UniTask.Delay(1000, cancellationToken: token);
				
				Log("End FadeOut.");
			}
			
			// TODO: FadeOut Process
			return FadeOut();
		}

		/// <summary>
		/// フェードイン
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public UniTask FadeInAsync(CancellationToken token = default)
		{
			async UniTask FadeIn()
			{
				Log("Start FadeIn.");
				
				await UniTask.Delay(1000, cancellationToken: token);
				
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