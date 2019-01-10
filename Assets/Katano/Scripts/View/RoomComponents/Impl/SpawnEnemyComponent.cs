using System;
using System.Linq;
using DDD.Matsumoto;
using DDD.Matsumoto.Character;
using UniRx;
using UnityEngine;

namespace DDD.Katano.View.RoomComponents
{
	/// <summary>
	/// 敵を生成するコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	public class SpawnEnemyComponent : BaseRoomComponent
	{
		private bool _isCaptured;
		
		private CharacterSpawner[] _spawners;
		
		private readonly AsyncSubject<Unit> _onRoomCapturedAsync = new AsyncSubject<Unit>();
		/// <summary>
		/// 敵を全滅させたイベント
		/// </summary>
		public IObservable<Unit> OnRoomCapturedAsync => _onRoomCapturedAsync;

		/// <inheritdoc />
		public override void OnInitialize()
		{
			_spawners = GetComponentsInChildren<CharacterSpawner>();
			
			Owner.OnEnterObservable.Subscribe(_ => Spawn());
		}

		private void Spawn()
		{
			// 敵をスポーンする
			var enemies = _spawners.Select(spawner => spawner.Spawn() as EnemyCore).ToList();

			// 敵が全滅したらイベントを発行
			enemies.Select(enemy => enemy.IsDead)
				.Merge()
				.Where(_ => enemies.All(enemy => enemy.IsDead.Value))
				.Subscribe(_ =>
				{
					Debug.Log($"[{Owner.Room.ToString()}] Enemies has been slain.");
					
					_onRoomCapturedAsync.OnNext(Unit.Default);
					_onRoomCapturedAsync.OnCompleted();
				});
			
			Debug.Log($"[{Owner.Room.ToString()}] Enemies was spawned.");
		}

		/// <summary>
		/// Debug command: Immediate Kill Enemies.
		/// </summary>
		[ContextMenu("KillEnemies")]
		public void ForceKillEnemies()
		{
			_onRoomCapturedAsync.OnNext(Unit.Default);
			_onRoomCapturedAsync.OnCompleted();
		}
	}
}