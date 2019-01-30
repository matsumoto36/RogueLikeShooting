using UniRx;
using UnityEngine.UI;
using Zenject;

namespace DDD.Matsumoto.UI
{
	/// <summary>
	///     プレイヤーのHPを表示するUI
	/// </summary>
	public class UIStatus : UIBase
	{
		[Inject]
		private PlayerHealthProvider _provider;

		public Image HPGauge;

		public override void Show()
		{
			base.Show();

			//プレイヤー生成前にShowすると発見できない(生成されていないため)
			_provider.CurrentHealth
				.Subscribe(health =>
				{
					ChangeGauge((float) health / _provider.MaxHealth);
				});
		}

		/// <summary>
		///     HPゲージを変更する
		/// </summary>
		/// <param name="amount"></param>
		private void ChangeGauge(float amount)
		{
			var scale = HPGauge.transform.localScale;
			scale.x = amount;
			HPGauge.transform.localScale = scale;
		}
	}
}