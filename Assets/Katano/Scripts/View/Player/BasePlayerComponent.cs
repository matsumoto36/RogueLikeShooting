using DDD.Matsumoto;
using UnityEngine;

namespace DDD.Katano.View.Player
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

		// public abstract void OnInitialize();
		
		/// <summary>
		/// 初期化(Start)
		/// </summary>
		public virtual void OnStart() {}
	}
}