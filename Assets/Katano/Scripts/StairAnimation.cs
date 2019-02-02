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

		public int Depth = 2;
		
		private Transform _transformCache;
		private static readonly int Color = Shader.PropertyToID("_Color");
		private static readonly int Alpha = Shader.PropertyToID("_alpha_width");

		// Start is called before the first frame update
		private void Start()
		{
			var material = MeshRenderer.material;
			material.SetColor(Color, StartColor);
			
			_transformCache = transform;

			var sequence = DOTween.Sequence();

			sequence
				//.Append(_transformCache.DOScaleY(Depth, 1).SetEase(Ease.InSine))
				.Append(DOTween.To(() => material.GetFloat(Alpha), x => material.SetFloat(Alpha, x), 0, 1)
					.SetEase(Ease.InSine));

			sequence.Play();
		}
	}
}