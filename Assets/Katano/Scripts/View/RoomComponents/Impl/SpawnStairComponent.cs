using UniRx;
using UnityEngine;
using Zenject;

namespace DDD.Katano.View.RoomComponents
{
	/// <summary>
	/// 階段を出現させるモジュール
	/// </summary>
	[DisallowMultipleComponent]
	public class SpawnStairComponent : BaseRoomComponent
	{
		[Inject]
		private StairView _stairPrefab;
		
		private EnemyRoomComponent _enemyRoomComponent;
		
		/// <inheritdoc />
		public override void OnInitialize()
		{
			_enemyRoomComponent = GetComponent<EnemyRoomComponent>();
			
			// 敵が全滅したら階段を出す
			_enemyRoomComponent
				.OnRoomCapturedAsync
				.Subscribe(_ => SpawnStair());
		}

		private void SpawnStair()
		{
			Instantiate(_stairPrefab, transform);
		}
	}
}