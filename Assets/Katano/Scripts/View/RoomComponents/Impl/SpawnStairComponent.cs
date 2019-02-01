using UniRx;
using UnityEngine;

namespace DDD.Katano.View.RoomComponents
{
	/// <summary>
	/// 階段を出現させるモジュール
	/// </summary>
	[DisallowMultipleComponent]
	public class SpawnStairComponent : BaseRoomComponent
	{
		private StairView _stairPrefab;
		private EnemyRoomComponent _enemyRoomComponent;

		/// <inheritdoc />
		public override void OnInitialize()
		{
			_enemyRoomComponent = GetComponent<EnemyRoomComponent>();
			_stairPrefab = Resources.Load<StairView>("Stairs");
			
			// 敵が全滅したら階段を出す
			_enemyRoomComponent
				.OnRoomCapturedAsync
				.Subscribe(_ => SpawnStair());
		}

		private void SpawnStair()
		{
			Instantiate(_stairPrefab, transform.localPosition, Quaternion.identity, transform);
		}
	}
}