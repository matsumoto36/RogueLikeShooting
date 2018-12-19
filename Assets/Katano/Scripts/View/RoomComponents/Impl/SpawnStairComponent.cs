using UniRx;
using UnityEngine;

namespace RogueLike.Katano.View.RoomComponents
{
	/// <summary>
	/// 階段を出現させるモジュール
	/// </summary>
	[DisallowMultipleComponent]
	public class SpawnStairComponent : BaseRoomComponent
	{
		private StairView _stairPrefab;
		private SpawnEnemyComponent _spawnEnemyComponent;

		/// <inheritdoc />
		public override void OnInitialize()
		{
			_spawnEnemyComponent = GetComponent<SpawnEnemyComponent>();
			_stairPrefab = Resources.Load<StairView>("Stairs");
			
			// 敵が全滅したら階段を出す
			_spawnEnemyComponent
				.OnRoomCapturedAsync
				.Subscribe(_ => SpawnStair());
		}

		private void SpawnStair()
		{
			Instantiate(_stairPrefab, transform.localPosition, Quaternion.identity, transform);
		}
	}
}