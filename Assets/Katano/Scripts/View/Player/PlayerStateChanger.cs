using UniRx;
using UniRx.Async;
using UnityEngine;

namespace DDD.Katano.View.Player
{
	/// <summary>
	/// プレイヤー状態変化クラス
	/// </summary>
	public class PlayerStateChanger : BasePlayerComponent
	{
		private readonly ReactiveProperty<PlayerState> _playerState = new ReactiveProperty<PlayerState>();
		public IReadOnlyReactiveProperty<PlayerState> PlayerState => _playerState;
		
		public UniTask DoChangeAsync(PlayerState playerState)
		{
			_playerState.Value = playerState;
			
			// animator.CrossFade("", 0.2f);
			
			return UniTask.CompletedTask;
		}
	}
}