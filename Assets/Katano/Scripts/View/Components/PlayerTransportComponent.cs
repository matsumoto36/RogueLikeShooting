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
		private PlayerTransporter _transporter;

		/// <inheritdoc />
		public override void OnInitialize()
		{
			_transporter = FindObjectOfType<PlayerTransporter>();
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