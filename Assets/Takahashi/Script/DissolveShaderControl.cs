using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DDD.Takahashi
{
	public class DissolveShaderControl : MonoBehaviour
	{
		private Transform _transformCache;
		private Renderer _renderer;

		private ShaderMode _shaderMode;
		
		[FormerlySerializedAs("b")]
		public bool ShowOnAwake;
		public Color c_emistion;

		private float f;
		public float h_max, h_min;
		private int i;
		private bool key;
		public float objy;
		public float speed;
		private static readonly int VJouge = Shader.PropertyToID("_v_jouge");
		private static readonly int Emission = Shader.PropertyToID("_emi_color");
		private static readonly int Height = Shader.PropertyToID("_takasa");

		// Use this for initialization
		private void Start()
		{
			_transformCache = transform;
			_renderer = GetComponent<Renderer>();
			
			if (ShowOnAwake)
			{
				_renderer.material.SetFloat(VJouge, h_max);
				f = h_max;
				
			}
			else
			{
				_renderer.material.SetFloat(VJouge, h_min);
				f = h_min;
			}
		}

		// Update is called once per frame
		private void Update()
		{
			objy = _transformCache.position.y;
			_renderer.material.SetFloat(Height, objy);
			_renderer.material.SetColor(Emission, c_emistion);
			SpawnManager();
		}

		public void Show()
		{
			_shaderMode = ShaderMode.Composite;
		}

		public void Hide()
		{
			_shaderMode = ShaderMode.Dissolve;
		}

		private void SpawnManager()
		{
			switch (_shaderMode)
			{
				case ShaderMode.Composite:
				{
					f -= speed;
					_renderer.material.SetFloat(VJouge, f);
					if (h_max >= f)
					{
						_shaderMode = ShaderMode.Neutral;
						f = h_max;
						i = 0;
					}
					break;
				}
				case ShaderMode.Dissolve:
				{
					
					f += speed;
					_renderer.material.SetFloat(VJouge, f);
					if (h_min <= f)
					{
						_shaderMode = ShaderMode.Neutral;
						key = false;
						f = h_min;
						i = 0;
					}
					break;
				}
			}
		}

		private enum ShaderMode
		{
			Neutral = 0,
			Composite,
			Dissolve,
		}
	}
}