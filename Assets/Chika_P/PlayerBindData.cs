using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace RogueLike.Chikazawa
{
    /// <summary>
    /// プレイヤーバインドデータ
    /// </summary>
    // [CreateAssetMenu(fileName = "EntryList", menuName = "EntrySystem")]
    public class PlayerBindData : ScriptableObject
    {
        /// <summary>
        /// エントリーリスト
        /// </summary>
        public List<int> PlayerEntries = new List<int>(4);
    }
}