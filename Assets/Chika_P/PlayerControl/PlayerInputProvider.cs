using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Chikazawa.InputEventProvider
{
    /// <summary>
    /// 入力の検知処理
    /// </summary>
    [Serializable]
    public abstract class PlayerInputProvider : IInputEventProvider
    {
        /// <summary>
        /// 移動入力を取得
        /// キーボード：WASDキー * 加速
        /// コントローラー：左スティック
        /// </summary>
        public abstract Vector3 GetMoveVector();
        /// <summary>
        /// 正面方向の入力(Y軸はプレイヤーの位置)
        /// キーボード：マウスの位置
        /// コントローラー：右スティック
        /// </summary>
        /// <returns>
        /// </returns>>
        public abstract Vector3 GetPleyerDirection(Vector3 playerPos);
        /// <summary>
        /// 攻撃(射撃)ボタン
        /// キーボード：左クリック
        /// コントローラー：L１ボタン
        /// </summary>
        /// <returns></returns>
        public abstract bool GetShotButton();
        /// <summary>
        /// 攻撃タメフラグ
        /// </summary>
        /// <returns></returns>
        public abstract bool GetShotDown();
        /// <summary>
        /// 攻撃放出フラグ
        /// </summary>
        /// <returns></returns>
        public abstract bool GetShotUp();
        /// <summary>
        /// 武器変更
        /// </summary>
        /// <returns></returns>
        public abstract bool GetChangeBody();
    }
}
