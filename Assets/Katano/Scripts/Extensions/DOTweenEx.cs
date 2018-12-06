using System;
using DG.Tweening;
using UniRx;
using UniRx.Async;

namespace Reqweldzen.Extensions
{
	public static class TweenExt
	{
		public static IObservable<Tween> AsObservable(this Tween self)
		{
			return Observable.Create<Tween>(observer =>
			{
				TweenCallback onComplete = null;
				onComplete = () =>
				{
					self.onComplete -= onComplete;
					observer.OnNext(self);
					observer.OnCompleted();
				};
				self.onComplete += onComplete;

				return Disposable.CreateWithState(self, t => t.Kill());
			});
		}
		
		public static IObservable<Sequence> AsObservable(this Sequence self)
		{
			return Observable.Create<Sequence>(observer =>
			{
				TweenCallback onComplete = null;
				onComplete = () =>
				{
					self.onComplete -= onComplete;
					observer.OnNext(self);
					observer.OnCompleted();
				};
				self.onComplete += onComplete;

				return Disposable.CreateWithState(self, t => t.Kill());
			});
		}

		public static UniTask<Tween>.Awaiter GetAwaiter(this Tween self)
		{
			var source = new UniTaskCompletionSource<Tween>();

			void OnComplete()
			{
				self.onComplete -= OnComplete;
				source.TrySetResult(self);
			}

			self.onComplete += OnComplete;

			return source.Task.GetAwaiter();
		}

		public static UniTask<Sequence>.Awaiter GetAwaiter(this Sequence self)
		{
			var source = new UniTaskCompletionSource<Sequence>();

			void OnComplete()
			{
				self.onComplete -= OnComplete;
				source.TrySetResult(self);
			}

			self.onComplete += OnComplete;

			return source.Task.GetAwaiter();
		}
	}
}