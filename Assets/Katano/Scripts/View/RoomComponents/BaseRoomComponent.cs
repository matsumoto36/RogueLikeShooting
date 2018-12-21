using UniRx;
using UnityEngine;

namespace DDD.Katano.View.RoomComponents
{
	/// <summary>
	/// 部屋コンポーネント
	/// </summary>
	public abstract class BaseRoomComponent : MonoBehaviour
	{
		protected RoomView Owner;
		
		private void Start()
		{
			Owner = GetComponent<RoomView>();

			Owner.OnInitializeAsync.Subscribe(_ => OnInitialize()).AddTo(this);

			OnStart();
		}
		
		/// <summary>
		/// 初期化
		/// </summary>
		public abstract void OnInitialize();
		public virtual void OnStart() {}
	}
}