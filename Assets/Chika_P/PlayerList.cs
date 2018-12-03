using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Chikazawa
{
    [CreateAssetMenu(fileName = "EntryList", menuName = "EntrySystem")]
    public class PlayerList : ScriptableObject
    {
        public int[] PList = new int[4];
    }
}