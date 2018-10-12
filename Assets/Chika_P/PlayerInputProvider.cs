using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Chikazawa.InputEventProvider
{
    /// <summary>
    /// 入力の検知処理
    /// </summary>
    public abstract class PlayerInputProvider : IInputEventProvider
    {
        
        /// <summary>
        /// 移動入力を取得
        /// キーボード：WASDキー * 加速
        /// </summary>
        public abstract Vector3 GetMoveVector();
        /// <summary>
        /// 正面方向の入力
        /// キーボード：マウスの位置(Y軸はプレイヤーの位置)
        /// </summary>
        /// <returns>
        /// </returns>>
        public abstract Vector3 GetPleyerDirection(Vector3 playerPos);
        /// <summary>
        /// 攻撃(射撃)ボタン
        /// キーボード：左クリック
        /// </summary>
        /// <returns></returns>
        public abstract bool GetShotButton();
    }
}
