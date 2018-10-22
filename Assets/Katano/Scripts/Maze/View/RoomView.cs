using UniRx;
using UnityEngine;

namespace RougeLike.Katano.Maze
{
	public class RoomView : MonoBehaviour
	{
		private Room _model;
		
		public void Initialize(Room observable)
		{
			_model = observable;

			this.ObserveEveryValueChanged(x => x._model.IsEnable)
				.SubscribeWithState(gameObject, (flag, go) => go.SetActive(flag))
				.AddTo(this);

//			Component.IsEnable
//				.SubscribeWithState(gameObject, (flag, go) => go.SetActive(flag))
//				.AddTo(this);


		}
	}
}