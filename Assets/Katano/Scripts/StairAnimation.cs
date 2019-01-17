using DDD.Katano.View;
using DG.Tweening;
using UniRx.Async;
using UnityEngine;

namespace DDD.Katano
{
	[RequireComponent(typeof(StairView))]
	public class StairAnimation : MonoBehaviour
	{
		public MeshRenderer MeshRenderer;
		
		public Color StartColor = new Color(1, 1, 1);
		public Color EndColor = new Color(0.5f, 0.5f, 0.5f);

		public int Depth = 1;
		
		private Transform _transformCache;
		private static readonly int In = Shader.PropertyToID("in");
		private static readonly int Out = Shader.PropertyToID("out");

		// Start is called before the first frame update
		private void Start()
		{
			var material = MeshRenderer.material;
			material.SetColor(In, StartColor);
			material.SetColor(Out, EndColor);
			
			_transformCache = transform;

			_transformCache.DOScaleY(Depth, 1).SetEase(Ease.InSine).Play();
		}
	}
}