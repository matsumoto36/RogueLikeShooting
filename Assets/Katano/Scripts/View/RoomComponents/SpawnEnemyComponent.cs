using System;
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
		private CharacterSpawner[] _spawners = new CharacterSpawner[0];
		
		private readonly AsyncSubject<Unit> _onEnemyDownAsync = new AsyncSubject<Unit>();
		/// <summary>
		/// 敵を全滅させたイベント
		/// </summary>
		public IObservable<Unit> OnEnemyDownAsync => _onEnemyDownAsync;

		/// <inheritdoc />
		public override void OnInitialize()
		{
			gameObject.Children().OfComponent<CharacterSpawner>().ToArrayNonAlloc(ref _spawners);
			
			Owner.OnEnterObservable.Subscribe(_ => Spawn());
		}

		private void Spawn()
		{
			// 敵をスポーンする
			var enemies = _spawners.Select(spawner => spawner.Spawn() as EnemyCore).ToList();

			// 敵が全滅したらイベントを発行
			enemies.Select(enemy => enemy.IsDead())
				.Merge()
				.Where(_ => enemies.All(enemy => enemy.IsDead().Value))
				.Subscribe(_ =>
				{
					_onEnemyDownAsync.OnNext(Unit.Default);
					_onEnemyDownAsync.OnCompleted();
				});
		}
	}

	public static class CharacterCoreEx
	{
		public static IReadOnlyReactiveProperty<bool> IsDead(this CharacterCore core)
		{
			return new BoolReactiveProperty(false);
		}
	}
}