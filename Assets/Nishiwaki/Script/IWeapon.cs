using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Matsumoto.Character;

namespace RogueLike.Nishiwaki
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
