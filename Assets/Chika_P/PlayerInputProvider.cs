using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Chikazawa.InputEventProvider
{
    /// <summary>
    /// 入力の検知処理
    /// </summary>
    public class PlayerInputProvider : IInputEventProvider
    {
        
        public Vector3 moveVec;        //移動方向
        public Vector3 forwardDir;     //正面方向
        public bool GetShot;           //攻撃入力
        
        /// <summary>
        /// 移動入力を取得
        /// キーボード：WASDキー * 加速
        /// </summary>
        public Vector3 GetMoveVector()
        {
            moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

            return moveVec;
        }
        /// <summary>
        /// 正面方向の入力
        /// キーボード：マウスの位置(Y軸はプレイヤーの位置)
        /// </summary>
        /// <returns>
        /// </returns>>
        public Vector3 GetPleyerDirection(Vector3 playerPos)
        {
            ///<summary>
            ///一部 参考にしました
            ///-> http://blog.uzutaka.com/entry/2015/10/14/031633
            ///</summary>
            
            // マウス位置を狙う
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //マウスの方向を向く、高さはプレイヤーのY軸に依存している
                forwardDir = new Vector3(hit.point.x, playerPos.y, hit.point.z);
            }

            return forwardDir;
        }
        /// <summary>
        /// 攻撃(射撃)ボタン
        /// キーボード：左クリック
        /// </summary>
        /// <returns></returns>
        public bool GetShotButton()
        {
            return GetShot;
        }
    }
}
