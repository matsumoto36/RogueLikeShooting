using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DDD.Takahashi
{
	public class DissolveShaderControl : MonoBehaviour
	{
		private static readonly int VJouge = Shader.PropertyToID("_v_jouge");
		private static readonly int Emission = Shader.PropertyToID("_emi_color");
		private static readonly int Height = Shader.PropertyToID("_takasa");
		
		private Transform _transformCache;
		private Renderer _renderer;
		private ShaderMode _shaderMode;
		private float _startValue;
		
		public bool UpperOnAwake;
		public Color EmissionColor;

		
		
		[Header("Emit Parameters")]
		public float UpperHeight;
		public float LowerHeight;
		
		
		public float Speed;
		
		public float PositionY { get; private set; }
		

		// Use this for initialization
		private void Start()
		{
			_transformCache = transform;
			_renderer = GetComponent<Renderer>();
			
			if (UpperOnAwake)
			{
				_renderer.material.SetFloat(VJouge, UpperHeight);
				_startValue = UpperHeight;
				
			}
			else
			{
				_renderer.material.SetFloat(VJouge, LowerHeight);
				_startValue = LowerHeight;
			}
		}

		// Update is called once per frame
		private void Update()
		{
			PositionY = _transformCache.position.y;
			_renderer.material.SetFloat(Height, PositionY);
			_renderer.material.SetColor(Emission, EmissionColor);
			SpawnManager();
		}

		public void Show()
		{
			_shaderMode = ShaderMode.Composite;
			_startValue = LowerHeight;
		}

		public void Hide()
		{
			_shaderMode = ShaderMode.Dissolve;
			_startValue = UpperHeight;
		}

		private void SpawnManager()
		{
			switch (_shaderMode)
			{
				case ShaderMode.Composite:
				{
					_startValue += Speed;
					_renderer.material.SetFloat(VJouge, _startValue);
					if (UpperHeight <= _startValue)
					{
						_shaderMode = ShaderMode.Neutral;
						_startValue = UpperHeight;
					}
					break;
				}
				case ShaderMode.Dissolve:
				{
					
					_startValue -= Speed;
					_renderer.material.SetFloat(VJouge, _startValue);
					if (LowerHeight >=_startValue)
					{
						_shaderMode = ShaderMode.Neutral;
						_startValue = LowerHeight;
					}
					break;
				}
			}
		}

		private enum ShaderMode
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