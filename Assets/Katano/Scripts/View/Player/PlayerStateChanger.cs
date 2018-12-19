using UniRx;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano.View.Player
{
	/// <summary>
	/// プレイヤー状態変化クラス
	/// </summary>
	public class PlayerStateChanger : MonoBehaviour
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