using System;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;

namespace DDD.Takahashi
{
	public class DissolveShaderControl : MonoBehaviour
	{
		private readonly Subject<(DissolveMode, float)> _dissolveSubject = new Subject<(DissolveMode, float)>();

		private readonly AsyncSubject<(float, float, Color)> _onInitializeSubject =
			new AsyncSubject<(float, float, Color)>();
		
		public IObservable<(float, float, Color)> OnInitialize => _onInitializeSubject;
		public IObservable<(DissolveMode, float)> OnDissolve => _dissolveSubject;

		private CancellationToken _cancellationToken;
		private Renderer _renderer;
		private float _startValue;

		private Transform _transformCache;

		public ColorReactiveProperty EffectColor;

		public float LowerHeight;

		public float Speed;

		public float UpperHeight;

		public bool UpperOnAwake;

		public ParticleAttraction Particle;

		private float Origin
		{
			get => _renderer.material.GetFloat(ParamId.Origin);
			set => _renderer.material.SetFloat(ParamId.Origin, value);
		}

		private float EmitHeight
		{
			get => _renderer.material.GetFloat(ParamId.EmitHeight);
			set => _renderer.material.SetFloat(ParamId.EmitHeight, value);
		}

		private float UnitSize => 1;

		private float PositionY => _transformCache.position.y;

		public bool IsActive { get; private set; }

		private void Awake()
		{
			_renderer = GetComponent<Renderer>();
		}

		// Use this for initialization
		private void Start()
		{
			_transformCache = transform;
			_cancellationToken = this.GetCancellationTokenOnDestroy();

			Origin = PositionY + UnitSize;
			EmitHeight = UpperOnAwake ? LowerHeight : UpperHeight;

			_onInitializeSubject.OnNext((!UpperOnAwake ? UpperHeight : LowerHeight, PositionY + UnitSize,
				EffectColor.Value));
			_onInitializeSubject.OnCompleted();

			EffectColor.Subscribe(color => _renderer.material.SetColor(ParamId.EmissionColor, color)).AddTo(this);
		}


		public void Show()
		{
			async UniTaskVoid CompositeAsync()
			{
				if (_cancellationToken.IsCancellationRequested) return;

				if (LowerHeight >= EmitHeight)
				{
					EmitHeight = LowerHeight;
					return;
				}

				IsActive = true;

				var emit = UpperHeight;
				EmitHeight = emit;

				while (!_cancellationToken.IsCancellationRequested)
				{
					emit -= Speed * Time.deltaTime;

					_dissolveSubject.OnNext((DissolveMode.Composite, emit));

					if (LowerHeight >= emit)
					{
						IsActive = false;
						EmitHeight = LowerHeight;
						return;
					}

					EmitHeight = emit;

					await UniTask.Yield();
					
					if (UpperHeight >= emit) Particle.Particle_emi = true;
					else Particle.Particle_emi = false;
				}
			}

			CompositeAsync().Forget();
		}

		public void Hide()
		{
			async UniTaskVoid DissolveAsync()
			{
				if (_cancellationToken.IsCancellationRequested) return;

				if (UpperHeight <= EmitHeight)
				{
					EmitHeight = UpperHeight;
					return;
				}

				IsActive = true;

				var emit = LowerHeight;
				EmitHeight = emit;

				while (!_cancellationToken.IsCancellationRequested)
				{
					emit += Speed * Time.deltaTime;
					_renderer.material.SetFloat(ParamId.EmitHeight, emit);

					_dissolveSubject.OnNext((DissolveMode.Dissolve, emit));

					if (UpperHeight <= emit)
					{
						IsActive = false;
						EmitHeight = UpperHeight;
						return;
					}

					if (UpperHeight >= emit) Particle.Particle_emi = true;
					else Particle.Particle_emi = false;

					await UniTask.Yield();
				}
			}

			DissolveAsync().Forget();
		}

		private static class ParamId
		{
			public static readonly int EmitHeight = Shader.PropertyToID("_v_jouge");
			public static readonly int EmissionColor = Shader.PropertyToID("_emi_color");
			public static readonly int Origin = Shader.PropertyToID("_takasa");
		}
		
		public enum DissolveMode
		{
			Neutral = 0,

			/// <summary>
			///     生成
			/// </summary>
			Composite,

			/// <summary>
			///     消滅
			/// </summary>
			Dissolve
		}
	}
}