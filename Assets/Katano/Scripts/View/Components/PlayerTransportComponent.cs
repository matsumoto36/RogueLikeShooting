using System.Collections.Generic;
using RogueLike.Matsumoto;
using UniRx;
using UniRx.Async;
using UniRx.Triggers;
using UnityEngine;

namespace RogueLike.Katano.View.Components
{
	/// <summary>
	/// プレイヤー転送システム
	/// </summary>
	public class PlayerTransportComponent : RoomComponent
	{
		[SerializeField]
		private Collider _bounds;
		
		private RoomView _owner;

		/// <summary>
		/// イベントを購読
		/// </summary>
		private void SetEvents()
		{
			_bounds.OnCollisionEnterAsObservable()
				.Where(x => x.gameObject.GetComponent<PlayerCore>())
				.Select(x => x.gameObject.GetComponent<PlayerCore>())
				.Subscribe(_ =>
				{
					
				});
		}

		public override void OnInitialize()
		{
			
		}
		
		public void Send()
		{
			
		}

		public void Receive(IEnumerable<PlayerCore> players)
		{
			Owner.Enter(players);
		}
	}
}