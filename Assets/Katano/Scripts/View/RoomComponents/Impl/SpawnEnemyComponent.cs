using System;
using System.Collections.Generic;
using System.Linq;
using RogueLike.Matsumoto;
using RogueLike.Matsumoto.Character;
using UniRx;
using Unity.Linq;
using UnityEngine;

namespace RogueLike.Katano.View.RoomComponents
{
	/// <summary>
	/// 敵を生成するコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	public class SpawnEnemyComponent : RoomComponent
	{
		private CharacterSpawner[] _spawners;
		
		private readonly AsyncSubject<Unit> _onEnemyDownAsync = new AsyncSubject<Unit>();
		/// <summary>
		/// 敵を全滅させたイベント
		/// </summary>
		public IObservable<Unit> OnEnemyDownAsync => _onEnemyDownAsync;

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
					
					_onEnemyDownAsync.OnNext(Unit.Default);
					_onEnemyDownAsync.OnCompleted();
				});
			
			Debug.Log($"[{Owner.Room.ToString()}] Enemies was spawned.");
		}

		[ContextMenu("KillEnemies")]
		public void ForceKillEnemies()
		{
			_onEnemyDownAsync.OnNext(Unit.Default);
			_onEnemyDownAsync.OnCompleted();
		}
	}
}