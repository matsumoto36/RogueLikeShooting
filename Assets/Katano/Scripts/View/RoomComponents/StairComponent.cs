using UniRx;
using UnityEngine;

namespace RogueLike.Katano.View.RoomComponents
{
	[DisallowMultipleComponent]
	public class StairComponent : RoomComponent
	{
		private StairView _stairObject;
		private SpawnEnemyComponent _spawnEnemyComponent;
		
		public override void OnInitialize()
		{
			_spawnEnemyComponent = GetComponent<SpawnEnemyComponent>();

			_stairObject = Resources.Load<StairView>("Stairs");
			
			// 敵が全滅したら階段を出す
			_spawnEnemyComponent
				.OnEnemyDownAsync
				.Subscribe(_ => Instantiate(_stairObject, transform.localPosition, Quaternion.identity));
		}
	}
}