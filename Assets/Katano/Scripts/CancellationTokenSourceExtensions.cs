using System.Threading;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;

namespace RougeLike.Katano
{
	public static class CancellationTokenSourceExtensions
	{
		public static void CancelWith(this CancellationTokenSource cts, Component component)
		{
			cts.CancelWith(component.gameObject);
		}

		public static void CancelWith(this CancellationTokenSource cts, GameObject gameObject)
		{
			gameObject.OnDestroyAsync().ContinueWith(() => cts.Cancel()).Forget();
		}
	}
}