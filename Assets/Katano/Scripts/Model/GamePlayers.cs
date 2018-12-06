using System.Collections.Generic;
using RogueLike.Matsumoto;
using RogueLike.Matsumoto.Character;
using UnityEngine;

namespace RogueLike.Katano.Model
{
	/// <summary>
	/// ゲームキャラクター
	/// </summary>
	// [CreateAssetMenu(fileName = "GamePlayers", menuName = "Maze/Game Characters")]
	public sealed class GamePlayers : ScriptableObject
	{
		private CharacterCore[] _playerList;

		/// <summary>
		/// プレイヤーリスト
		/// </summary>
		public IEnumerable<CharacterCore> PlayerList => _playerList;

		/// <summary>
		/// プレイヤーを設定する
		/// </summary>
		/// <param name="players"></param>
		public void Register(CharacterCore[] players)
		{
			_playerList = players;
		}
	}
}