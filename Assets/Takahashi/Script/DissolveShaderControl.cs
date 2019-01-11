using System;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using UniRx.Triggers;
using UnityEngine;

namespace DDD.Takahashi
{
	public class DissolveShaderControl : MonoBehaviour
	{
		private static readonly int Border = Shader.PropertyToID("_v_jouge");
		private static readonly int Emission = Shader.PropertyToID("_emi_color");
		private static readonly int Height = Shader.PropertyToID("_takasa");
		
		private Transform _transformCache;
		private Renderer _renderer;
		private float _startValue;
		
		public bool UpperOnAwake;
		public ColorReactiveProperty EmissionColor;		
		
		[Header("Emit Parameters")]
		public float UpperHeight;
		public float LowerHeight;
		
		
		public float Speed;

		public float PositionY => _transformCache.position.y;

		private CancellationToken _cancellationToken;

		private void Awake()
		{
			_transformCache = transform;
			_renderer = GetComponent<Renderer>();
		}
		
		// Use this for initialization
		private void Start()
		{
			_cancellationToken = this.GetCancellationTokenOnDestroy();
			
			_renderer.material.SetFloat(Border, UpperOnAwake ? UpperHeight : LowerHeight);

			this.UpdateAsObservable().Subscribe(_ => _renderer.material.SetFloat(Height, PositionY));
			EmissionColor.Subscribe(color => _renderer.material.SetColor(Emission, color)).AddTo(this);
		}

		private readonly Subject<(DissolveMode, float)> _dissolveSubject = new Subject<(DissolveMode, float)>();
		public IObservable<(DissolveMode, float)> OnDissolve => _dissolveSubject;
		
		public void Show()
		{
			async UniTaskVoid CompositeAsync()
			{
				var delta = LowerHeight;
				_renderer.material.SetFloat(Border, delta);
				
				while (!_cancellationToken.IsCancellationRequested)
				{
					delta += Speed * Time.deltaTime;
					_renderer.material.SetFloat(Border, delta);
						
					_dissolveSubject.OnNext((DissolveMode.Composite, delta));
					
					if (UpperHeight <= delta)
					{
						_startValue = UpperHeight;
						break;
					}

					await UniTask.Yield();
				}
			}
			
			_startValue = LowerHeight;

			CompositeAsync().Forget();
		}

		public void Hide()
		{
			async UniTaskVoid DissolveAsync()
			{
				while (!_cancellationToken.IsCancellationRequested)
				{
					_startValue -= Speed;
					_renderer.material.SetFloat(Border, _startValue);
					if (LowerHeight >= _startValue)
					{
						_startValue = LowerHeight;
					}

					await UniTask.Yield();
				}
			}
			
			_startValue = UpperHeight;

			DissolveAsync().Forget();
		}

		public enum DissolveMode
		{
			Neutral = 0,
			/// <summary>
			/// 生成
			/// </summary>
			Composite,
			/// <summary>
			/// 消滅
			/// </summary>
			Dissolve,
		}
	}
}