using System;
using UniRx;
using UnityEngine;

namespace DDD.Matsumoto
{
	/// <summary>
	///     プレイヤーで共有のHPを提供する
	/// </summary>
	public class PlayerHealthProvider
	{
		private readonly IntReactiveProperty _currentHealth;
		public IReadOnlyReactiveProperty<int> CurrentHealth => _currentHealth;
		
		public int MaxHealth { get; }
		
		public IReadOnlyReactiveProperty<bool> IsDead { get; }

		public PlayerHealthProvider(int health)
		{
			_currentHealth = new IntReactiveProperty(health);
			MaxHealth = health;
			IsDead = CurrentHealth.Select(x => x <= 0).ToReactiveProperty();
		}

		public void TakeDamage(int value)
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException(nameof(value), "value less than 0!");

			_currentHealth.Value = Mathf.Clamp(_currentHealth.Value - value, 0, MaxHealth);
		}
	}
}