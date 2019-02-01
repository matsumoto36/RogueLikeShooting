using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DDD.Matsumoto.UI {

	/// <summary>
	/// 武器変更時のUI
	/// </summary>
	public class UIWeaponChange : UIBase {

		public Image FillImage;
		public GameObject ControllerButtonImage;
		public GameObject KeyboardButtonImage;

		public void Start() {

			//初期設定
			SetControllerType(false);
			SetAmount(0);

		}

		/// <summary>
		/// 乗っ取り状態を設定
		/// </summary>
		/// <param name="amount"></param>
		public void SetAmount(float amount) {
			FillImage.fillAmount = amount;
		}

		/// <summary>
		/// ボタンの画像タイプを設定
		/// </summary>
		/// <param name="isKeyboard"></param>
		public void SetControllerType(bool isKeyboard) {
			ControllerButtonImage.SetActive(!isKeyboard);
			KeyboardButtonImage.SetActive(isKeyboard);
		}
	}
}

