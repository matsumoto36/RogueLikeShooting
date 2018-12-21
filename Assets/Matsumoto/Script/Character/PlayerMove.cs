using DDD.Katano.View.Player;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace DDD.Matsumoto.Character
{
	public class PlayerMove : BasePlayerComponent
	{
		private Transform _playerTransform;

		public override void OnStart()
		{
			_playerTransform = Player.transform;

			this.UpdateAsObservable()
				.Where(_ => !Player.IsFreeze.Value)
				//武器切り替え時は移動キャンセル
				.Where(_ => Player.ChangeTargetWeapon == null)
				.Subscribe(_ => Move())
				.AddTo(this);

//			Player.PlayerUpdate
//				.Where(player => player.InputEventProvider != null)
//				//武器切り替え時は移動キャンセル
//				.Where(player => player.ChangeTargetWeapon == null)
//				.Subscribe(player =>
//				{
//					var inputProvider = player.InputEventProvider;
//					
//					var position = _playerTransform.position;
//
//					// TODO: weight is Depends on weapons
//					const float weight = 5;
//					var deltaSpeed = weight * Time.deltaTime;
//					position += inputProvider.GetMoveVector() * deltaSpeed;
//
//					// 向きの変更
//					var direction = inputProvider.GetPleyerDirection(position) - position;
//
//					_playerTransform.position = position;
//					_playerTransform.rotation = Quaternion.LookRotation(direction);
//				})
//				.AddTo(this);
		}

		private void Move()
		{
			// TODO: weight is Depends on weapons
			const float weight = 5;
			
			var inputProvider = Player.InputEventProvider;
			var position = _playerTransform.position;

			
			var deltaSpeed = weight * Time.deltaTime;
			position += inputProvider.GetMoveVector() * deltaSpeed;

			// 向きの変更
			var direction = inputProvider.GetPleyerDirection(position) - position;

			_playerTransform.position = position;
			_playerTransform.rotation = Quaternion.LookRotation(direction);
		}
	}
}