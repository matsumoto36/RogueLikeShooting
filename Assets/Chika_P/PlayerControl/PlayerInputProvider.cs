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
        /// コントローラー：左スティック
        /// </summary>
        public abstract Vector3 GetMoveVector(int controllerNo);
        /// <summary>
        /// 正面方向の入力(Y軸はプレイヤーの位置)
        /// キーボード：マウスの位置
        /// コントローラー：右スティック
        /// </summary>
        /// <returns>
        /// </returns>>
        public abstract Vector3 GetPleyerDirection(Vector3 playerPos, int controllerNo);
        /// <summary>
        /// 攻撃(射撃)ボタン
        /// キーボード：左クリック
        /// コントローラー：L１ボタン
        /// </summary>
        /// <returns></returns>
        public abstract bool GetShotButton(int controllerNo);
        /// <summary>
        /// 攻撃タメフラグ
        /// </summary>
        /// <returns></returns>
        public abstract bool GetShotDown(int controllerNo);
        /// <summary>
        /// 攻撃放出フラグ
        /// </summary>
        /// <returns></returns>
        public abstract bool GetShotUp(int controllerNo);
    }
}
