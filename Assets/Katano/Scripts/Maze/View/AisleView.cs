using UniRx;
using UnityEngine;

namespace RogueLike.Katano.Maze
{
	/// <summary>
	/// 通路
	/// </summary>
	public class AisleView : MonoBehaviour
	{
		private Aisle _model;

		public void Subscribe(Aisle observable)
		{
			_model = observable;

			this.ObserveEveryValueChanged(x => x._model.IsEnable)
				.Subscribe(x => gameObject.SetActive(x))
				.AddTo(this);
			
			// _model.IsEnable.Subscribe(x => gameObject.SetActive(x)).AddTo(this);
		}
	}
}