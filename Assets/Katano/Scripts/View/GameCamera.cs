using DG.Tweening;
using Reqweldzen.Extensions;
using UniRx.Async;
using UnityEngine;

namespace DDD.Katano.View
{
	/// <summary>
	/// ゲームカメラ
	/// </summary>
	[DisallowMultipleComponent]
	public class GameCamera : MonoBehaviour
	{
		private Transform _transformCache;
		
		public RoomView FocusTarget { get; private set; }

		private void Start()
		{
			_transformCache = transform;
		}

		public void Initialize(RoomView initRoom)
		{
			FocusTarget = initRoom;
			_transformCache.position = FocusTarget.GameCameraAnchor.position;
			_transformCache.rotation = FocusTarget.GameCameraAnchor.rotation;
		}
		
		/// <summary>
		/// 部屋を移動する
		/// </summary>
		/// <param name="nextRoom"></param>
		/// <returns></returns>
		public async UniTask MoveAsync(RoomView nextRoom)
		{
			var start = FocusTarget.GameCameraAnchor.transform.position;
			var end = nextRoom.GameCameraAnchor.transform.position;
			var tween = DOTween.To(() => start, x => transform.position = x, end, 2f).SetEase(Ease.Linear);

			await tween.Play();
			
			FocusTarget = nextRoom;
		}
	}
}