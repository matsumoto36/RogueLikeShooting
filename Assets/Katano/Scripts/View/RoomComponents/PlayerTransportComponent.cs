using System.Collections.Generic;
using RogueLike.Matsumoto;
using UnityEngine;

namespace RogueLike.Katano.View.RoomComponents
{
	/// <summary>
	/// プレイヤー転送システム
	/// </summary>
	[DisallowMultipleComponent]
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