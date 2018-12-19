using DG.Tweening;
using Reqweldzen.Extensions;
using UniRx.Async;
using UnityEngine;

namespace RogueLike.Katano.View
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
			transform.position = FocusTarget.GameCameraAnchor.position;
			transform.rotation = FocusTarget.GameCameraAnchor.rotation;
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