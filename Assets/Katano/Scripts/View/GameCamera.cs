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
		
		/// <summary>
		/// 部屋を移動する
		/// </summary>
		/// <param name="nextRoom"></param>
		/// <returns></returns>
		public async UniTask MoveAsync(RoomView nextRoom)
		{
			var current = FocusTarget;
			var tween = DOTween.To(
				() => current.GameCameraAnchor.position, 
				x => transform.position = x,
				nextRoom.GameCameraAnchor.position,
				2f)
				.SetEase(Ease.Linear);

			await tween.Play();
			
			FocusTarget = nextRoom;
		}
	}
}