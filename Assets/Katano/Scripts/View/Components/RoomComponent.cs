using UniRx;
using UnityEngine;

namespace RogueLike.Katano.View.Components
{
	/// <summary>
	/// 部屋コンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	public abstract class RoomComponent : MonoBehaviour
	{
		protected RoomView Owner;
		
		private void Start()
		{
			Owner = GetComponent<RoomView>();

			Owner.OnInitialize.Subscribe(_ => OnInitialize()).AddTo(this);

			OnStart();
		}
		
		/// <summary>
		/// 初期化
		/// </summary>
		public abstract void OnInitialize();
		public virtual void OnStart() {}

		public virtual void Spawn() {}
	}
}