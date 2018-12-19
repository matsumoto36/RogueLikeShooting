using UniRx;
using UnityEngine.UI;

namespace RogueLike.Matsumoto.UI {

	/// <summary>
	/// プレイヤーのHPを表示するUI
	/// </summary>
	public class UIStatus : UIBase {

		public Image HPGauge;

		private PlayerHPProvider _provider;

		public override void Show() {
			base.Show();

			//プレイヤー生成前にShowすると発見できない(生成されていないため)
			if (!_provider) {
				_provider = FindObjectOfType<PlayerHPProvider>();
				_provider
					.ObserveEveryValueChanged(x => x.NowHP)
					.Subscribe(health => ChangeGauge((float)health / _provider.MaxHP));
			}
		}

		/// <summary>
		/// HPゲージを変更する
		/// </summary>
		/// <param name="amount"></param>
		private void ChangeGauge(float amount) {

			var scale = HPGauge.transform.localScale;
			scale.x = amount;
			HPGauge.transform.localScale = scale;
		}
	}
}