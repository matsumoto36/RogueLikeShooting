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
    [CreateAssetMenu(fileName = "PlayerBindData", menuName = "Game/Player Bind Data")]
    public class PlayerBindData : ScriptableObject
    {
        /// <summary>
        /// エントリーリスト
        /// </summary>
        public List<ControllerIndex> PlayerEntries = new List<ControllerIndex>(4);
    }
}