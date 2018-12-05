using UnityEngine;

/// <summary>
///     シングルトンの親クラス
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	public static T Instance
	{
		get
		{
			if (!_instance) Create();
			return _instance;
		}
	}

	//[RuntimeInitializeOnLoadMethod]
	private static void Create()
	{
		_instance = new GameObject($"[Singleton - {typeof(T)}]")
			.AddComponent<T>();

		_instance.GetComponent<SingletonMonoBehaviour<T>>().Init();

		DontDestroyOnLoad(_instance.gameObject);
	}

	/// <summary>
	///     初期化用
	/// </summary>
	protected virtual void Init()
	{
	}

	private void Awake()
	{
		if (!_instance) {
			_instance = GetComponent<T>();
			name = $"[Singleton - {typeof(T)}]";
			_instance.GetComponent<SingletonMonoBehaviour<T>>().Init();

			DontDestroyOnLoad(_instance.gameObject);
		}
		else {
			Destroy(gameObject);
		}
	}
}