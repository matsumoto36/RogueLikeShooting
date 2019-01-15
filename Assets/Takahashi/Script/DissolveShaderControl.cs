using System;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Serialization;

namespace DDD.Takahashi
{
	public class DissolveShaderControl : MonoBehaviour
	{
		private static class ParamId
		{
			public static readonly int EmitHeight = Shader.PropertyToID("_v_jouge");
			public static readonly int EmissionColor = Shader.PropertyToID("_emi_color");
			public static readonly int Origin = Shader.PropertyToID("_takasa");
		}

		private float EmitHeight
		{
			get => _renderer.material.GetFloat(ParamId.EmitHeight);
			set => _renderer.material.SetFloat(ParamId.EmitHeight, value);
		}

		private Transform _transformCache;
		private Renderer _renderer;
		private float _startValue;
		
		public bool UpperOnAwake;
		[FormerlySerializedAs("EmissionColor")]
		public ColorReactiveProperty EffectColor;		
		
		[Header("Emit Parameters")]
		public float UpperHeight;
		public float LowerHeight;

		private float UnitSize => 1;
		
		public float Speed;

		private float PositionY => _transformCache.position.y;

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
			_renderer.material.SetFloat(ParamId.Origin, PositionY + UnitSize);
			
			_renderer.material.SetFloat(ParamId.EmitHeight, !UpperOnAwake ? UpperHeight : LowerHeight);
			
			_onInitializeSubject.OnNext((!UpperOnAwake ? UpperHeight : LowerHeight, PositionY + UnitSize, EffectColor.Value));
			_onInitializeSubject.OnCompleted();
			
			EffectColor.Subscribe(color => _renderer.material.SetColor(ParamId.EmissionColor, color)).AddTo(this);
		}
		
		private readonly AsyncSubject<(float, float, Color)> _onInitializeSubject = new AsyncSubject<(float, float, Color)>();
		public IObservable<(float, float, Color)> OnInitialize => _onInitializeSubject;

		private readonly Subject<(DissolveMode, float)> _dissolveSubject = new Subject<(DissolveMode, float)>();
		public IObservable<(DissolveMode, float)> OnDissolve => _dissolveSubject;
		
		public void Show()
		{
			async UniTaskVoid CompositeAsync()
			{
				var emit = UpperHeight;
				EmitHeight = emit;
				
				while (!_cancellationToken.IsCancellationRequested)
				{
					emit -= Speed * Time.deltaTime;
					_renderer.material.SetFloat(ParamId.EmitHeight, emit);
						
					_dissolveSubject.OnNext((DissolveMode.Composite, emit));
					
					if (LowerHeight >= emit)
					{
						EmitHeight = LowerHeight;
						break;
					}

					await UniTask.Yield();
				}
			}

			CompositeAsync().Forget();
		}

		public void Hide()
		{
			async UniTaskVoid DissolveAsync()
			{
				var emit = LowerHeight;
				EmitHeight = emit;
				
				while (!_cancellationToken.IsCancellationRequested)
				{
					emit += Speed * Time.deltaTime;
					_renderer.material.SetFloat(ParamId.EmitHeight, emit);
					
					_dissolveSubject.OnNext((DissolveMode.Dissolve, emit));

					if (UpperHeight <= emit)
					{
						EmitHeight = UpperHeight;
						break;
					}

					await UniTask.Yield();
				}
			}

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