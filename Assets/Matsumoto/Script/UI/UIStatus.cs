﻿using UniRx;
using UnityEngine.UI;
using UnityEngine;
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

		[Inject]
		private IMessageReceiver _messageReceiver;

		public Slider HPGauge;
		public Image DamageEffect;
		public Text HPText;

		public Text FloorText;

		private void Start() {

			DamageEffect.material.SetFloat("_range", 0);

			_messageReceiver.Receive<Katano.MazeSignal.FloorConstruct>()
				.Subscribe(signal => FloorText.text = signal.FloorNum + "F");

			_provider.CurrentHealth
				.Subscribe(health => {
					ChangeGauge((float)health / _provider.MaxHealth);
					HPText.text = health.ToString();
				});
		}

		public override void Show()
		{
			base.Show();
		}

		/// <summary>
		///     HPゲージを変更する
		/// </summary>
		/// <param name="amount"></param>
		private void ChangeGauge(float amount) {
			Debug.Log("Health ratio : " + amount);
			HPGauge.value = amount;
			//めっちゃ重い(エディタのみ)
			if(!Application.isEditor)
				DamageEffect.material.SetFloat("_range", 3 - amount * 3);
		}
	}
}