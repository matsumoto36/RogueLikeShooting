using RogueLike.Katano.View.Player;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace RogueLike.Matsumoto.Character
{
	/// <summary>
	///     プレイヤーの攻撃を行う
	/// </summary>
	public class PlayerAttack : BasePlayerComponent
	{
		private bool _isUsingWeapon;

		public override void OnStart()
		{
			this.UpdateAsObservable()
				.Where(_ => !Player.IsFreeze.Value)
				.Where(_ => Player.InputEventProvider != null)
				.Subscribe(_ => Attack())
				.AddTo(this);


//			Player.PlayerUpdate
//				.Where(player => player.InputEventProvider != null)
//				.Subscribe(player =>
//				{
//					//武器切り替え時は攻撃キャンセル
//					if (player.ChangeTargetWeapon != null)
//					{
//						if (!isUsingWeapon) return;
//
//						player.Weapon?.AttackUp();
//						isUsingWeapon = false;
//						return;
//					}
//
//					if (player.InputEventProvider.GetShotDown() && !isUsingWeapon)
//					{
//						player.Weapon?.AttackDown();
//						isUsingWeapon = true;
//					}
//
//					if (player.InputEventProvider.GetShotButton() && isUsingWeapon)
//						player.Weapon?.Attack();
//
//					if (player.InputEventProvider.GetShotUp() && isUsingWeapon)
//					{
//						player.Weapon?.AttackUp();
//						isUsingWeapon = false;
//					}
//				});
		}

		/// <summary>
		/// 攻撃
		/// </summary>
		private void Attack()
		{
			//武器切り替え時は攻撃キャンセル
			if (Player.ChangeTargetWeapon != null)
			{
				if (!_isUsingWeapon) return;

				Player.Weapon?.AttackUp();
				_isUsingWeapon = false;
				return;
			}

			if (Player.InputEventProvider.GetShotDown() && !_isUsingWeapon)
			{
				Player.Weapon?.AttackDown();
				_isUsingWeapon = true;
			}

			if (Player.InputEventProvider.GetShotButton() && _isUsingWeapon)
				Player.Weapon?.Attack();

			if (Player.InputEventProvider.GetShotUp() && _isUsingWeapon)
			{
				Player.Weapon?.AttackUp();
				_isUsingWeapon = false;
			}
		}
	}
}