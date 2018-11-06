using UniRx;
using UniRx.Async;
using UniRx.Triggers;
using UnityEngine;

namespace RogueLike.Katano.Maze
{
	public class RoomView : MonoBehaviour
	{
		
		[SerializeField]
		private BoxCollider _roomBounds;
		
		

		public async UniTaskVoid SpawnEnemyAsync()
		{
			var collision = await _roomBounds.OnCollisionEnterAsObservable().ToUniTask();

			
		}
	}
}