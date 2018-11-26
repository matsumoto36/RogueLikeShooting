using UnityEngine;

/// <summary>
///     シングルトンの親クラス
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	public static T instance
	{
		get
		{
			if (!_instance) Create();
			return _instance;
		}
	}

	private static void Create()
	{
		_instance = new GameObject($"[Singleton - {typeof(T)}]")
			.AddComponent<T>();

		DontDestroyOnLoad(_instance.gameObject);

		_instance.GetComponent<SingletonMonoBehaviour<T>>().Init();
	}

	/// <summary>
	///     初期化用
	/// </summary>
	protected virtual void Init()
	{
	}

	private void Awake()
	{
		if (_instance)
		{
			Destroy(gameObject);
			return;
		}
		
		Create();
	}
}