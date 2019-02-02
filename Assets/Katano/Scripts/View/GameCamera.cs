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
		
		public RoomView FocusTarget { get; private set; }


		public void Initialize(RoomView initRoom)
		{
			FocusTarget = initRoom;
			var transform1 = transform;
			transform1.position = FocusTarget.GameCameraAnchor.position;
			transform1.rotation = FocusTarget.GameCameraAnchor.rotation;
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