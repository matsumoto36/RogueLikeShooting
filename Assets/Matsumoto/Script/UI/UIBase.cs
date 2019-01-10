using System;
using DDD.Matsumoto.Managers;
using UnityEngine;

namespace DDD.Matsumoto.UI
{
	/// <summary>
	///     すべてのUIの親クラス
	/// </summary>
	public class UIBase : MonoBehaviour
	{
		public bool IsInitialized { get; private set; }

		public event Action OnInitialized;
		public event Action<UIBase> OnShowed;
		public event Action<UIBase> OnHided;


		private void Awake()
		{
			Initialize();
		}

		public void Initialize()
		{
			if (IsInitialized) return;
			IsInitialized = true;

			//UIマネージャーに登録
			UIManager.Instance.Register(this);

			OnInitialized?.Invoke();
		}

		/// <summary>
		///     UIを表示する
		/// </summary>
		public virtual void Show()
		{
			gameObject.SetActive(true);
			OnShowed?.Invoke(this);
		}

		/// <summary>
		///     UIを隠す
		/// </summary>
		public virtual void Hide()
		{
			gameObject.SetActive(false);
			OnHided?.Invoke(this);
		}
	}
}