using UniRx;
using UnityEngine;

namespace RougeLike.Katano.Maze
{
	public class AisleView : MonoBehaviour
	{
		private Aisle _model;

		public void Subscribe(Aisle observable)
		{
			_model = observable;

			_model.IsEnable.Subscribe(x => gameObject.SetActive(x)).AddTo(this);
		}
	}
}