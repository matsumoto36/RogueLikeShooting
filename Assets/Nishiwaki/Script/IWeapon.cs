﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Nishiwaki
{
    public interface IWeapon
    {
        void SetOwner(Matsumoto.Character.CharacterCore character);

        void Attack();
        void AttackUp();
        void AttackDown();
    }
}
