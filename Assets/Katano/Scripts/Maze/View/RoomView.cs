using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace RougeLike.Katano.Maze
{
	public class RoomView : MonoBehaviour
	{
		private static readonly Color[] ColorTable =
		{
			Color.white,
			Color.red,
			Color.yellow,
			Color.green,
			Color.cyan,
			Color.blue,
			Color.magenta
		};
		
		[SerializeField]
		private Text _label;
		
		[SerializeField]
		private MeshRenderer _renderer;
		
		public Room Component { get; private set; }
		
		public void Initialize(Room component)
		{
			Component = component;

			Component.IsEnable
				.SubscribeWithState(gameObject, (flag, go) => go.SetActive(flag))
				.AddTo(this);
		}
	}
}