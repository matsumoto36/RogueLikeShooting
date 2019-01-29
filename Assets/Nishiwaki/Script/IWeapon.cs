using DDD.Matsumoto.Character;
using UnityEngine;

namespace DDD.Nishiwaki
{
	public interface IWeapon
	{
		void SetOwner(CharacterCore character);
		CharacterCore GetOwner();
		GameObject GetBody();
		Transform PlayerSetPosition();
		void Attack();
		void AttackUp();
		void AttackDown();
	}
}