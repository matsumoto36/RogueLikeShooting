using System.Collections.Generic;
using DDD.Matsumoto;
using DDD.Matsumoto.Character;
using UnityEngine;

namespace DDD.Katano.Model
{
	/// <summary>
	/// ゲームキャラクター
	/// </summary>
	// [CreateAssetMenu(fileName = "GamePlayers", menuName = "Maze/Game Characters")]
	public sealed class GamePlayers : ScriptableObject
	{
		private PlayerCore[] _playerList;

		/// <summary>
		/// プレイヤーリスト
		/// </summary>
		public IEnumerable<PlayerCore> PlayerList => _playerList;
		
		public int JoinedPlayerCount { get; private set; }

		/// <summary>
		/// プレイヤーを設定する
		/// </summary>
		/// <param name="players"></param>
		public void Register(PlayerCore[] players)
		{
			_playerList = players;
			JoinedPlayerCount = players.Length;
		}
	}
}