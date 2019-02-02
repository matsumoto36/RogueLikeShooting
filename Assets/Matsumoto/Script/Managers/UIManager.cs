using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DDD.Matsumoto.UI;

namespace DDD.Matsumoto.Managers {

	public class UIManager : SingletonMonoBehaviour<UIManager> {

		private Dictionary<string, UIBase> _UIList
			= new Dictionary<string, UIBase>();

		

		public void Initialize() {

		}

		/// <summary>
		/// UIを登録(キーは名前)
		/// </summary>
		/// <param name="uiBase"></param>
		public void Register(UIBase uiBase) {
			_UIList.Add(uiBase.name, uiBase);
		}

		/// <summary>
		/// UIを登録解除(キーは名前)
		/// </summary>
		/// <param name="uiBase"></param>
		public void UnRegister(UIBase uiBase) {
			_UIList.Remove(uiBase.name);
		}

		/// <summary>
		/// UIを取得
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public UIBase GetUiBase(string name) {
			return _UIList[name];
		}

		/// <summary>
		/// 指定したUIを表示する
		/// </summary>
		/// <param name="name"></param>
		public void Show(string name) {
			_UIList[name].Show();
		}

		/// <summary>
		/// 指定したUIを表示する
		/// </summary>
		/// <param name="name"></param>
		public void Hide(string name) {
			_UIList[name].Hide();
		}

	}

}
