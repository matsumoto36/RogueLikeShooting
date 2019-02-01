using DDD.Katano.View.Player;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace DDD.Matsumoto.Character
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
		private void Attack() {

			var weapon = Player.CharacterArm.EquippedArm;

			//武器切り替え時は攻撃キャンセル
			if (Player.ChangeTargetWeapon != null)
			{
				if (!_isUsingWeapon) return;

				weapon?.AttackUp();
				_isUsingWeapon = false;
				return;
			}

			if (Player.InputEventProvider.GetShotDown() && !_isUsingWeapon)
			{
				weapon?.AttackDown();
				_isUsingWeapon = true;
			}

			if (Player.InputEventProvider.GetShotButton() && _isUsingWeapon)
				weapon?.Attack();

			if (Player.InputEventProvider.GetShotUp() && _isUsingWeapon)
			{
				weapon?.AttackUp();
				_isUsingWeapon = false;
			}
		}
	}
}