using RogueLike.Matsumoto;
using UnityEngine;

namespace RogueLike.Katano.View.Player
{
	[RequireComponent(typeof(PlayerCore))]
	public abstract class BasePlayerComponent : MonoBehaviour
	{
		protected PlayerCore Player;
		
		private void Start()
		{
			Player = GetComponent<PlayerCore>();

			// Player.OnInitializeAsync.Subscribe(_ => OnInitialize()).AddTo(this);

			OnStart();
		}
		
		/// <summary>
		/// 初期化
		/// </summary>
		// public abstract void OnInitialize();
		
		/// <summary>
		/// 初期化(Start)
		/// </summary>
		public virtual void OnStart() {}
	}
}