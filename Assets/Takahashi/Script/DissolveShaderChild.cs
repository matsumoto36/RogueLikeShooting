using System;
using UniRx;
using UnityEngine;

namespace DDD.Takahashi
{
	public class DissolveShaderChild : MonoBehaviour
	{
		private static class ParamId
		{
			public static readonly int EmitHeight = Shader.PropertyToID("_v_jouge");
			public static readonly int EmissionColor = Shader.PropertyToID("_emi_color");
			public static readonly int Origin = Shader.PropertyToID("_takasa");
		}
		
		private DissolveShaderControl _parentController;
		private Renderer _renderer;
		
		// Use this for initialization
		private void Start()
		{
			var parent = transform.parent;
			if (parent == null)
				throw new UnityException("Parent gameobject not found.");
			
			_parentController = parent.GetComponentInParent<DissolveShaderControl>();
			if (_parentController == null)
				throw new UnityException("Parent Shader Controller not found.");

			_renderer = GetComponent<Renderer>();

			_parentController.OnInitialize.Subscribe(tuple =>
			{
				var (emit, origin, color) = tuple;
				_renderer.material.SetFloat(ParamId.EmitHeight, emit);
				_renderer.material.SetFloat(ParamId.Origin, origin);
				_renderer.material.SetColor(ParamId.EmissionColor, color);
			});
			
			_parentController.OnDissolve.Subscribe(param =>
			{
				var (mode, value) = param;
				switch (mode)
				{
					case DissolveShaderControl.DissolveMode.Composite:
					{
						_renderer.material.SetFloat(ParamId.EmitHeight, value);
						break;
					}
					case DissolveShaderControl.DissolveMode.Dissolve:
					{
						_renderer.material.SetFloat(ParamId.EmitHeight, value);
						break;
					}
					default:
						throw new ArgumentOutOfRangeException();
				}
			});
		}
	}
}