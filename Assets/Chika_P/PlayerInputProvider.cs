using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Chikazawa.InputEventProvider
{
    /// <summary>
    /// 入力の検知処理
    /// </summary>
    public class PlayerInputProvider : MonoBehaviour ,IPlayerController
    {
        
        Vector3 moveVec;        //移動方向
        Vector3 forwardDir;     //正面方向
        Vector3 bulletForward;  //射撃方向
        [SerializeField]
        GameObject PlayerObj;   //操作するプレイヤー
        [SerializeField]
        float accel;        //加速度
        
        /// <summary>
        /// 移動入力を取得
        /// キーボード：WASDキー * 加速
        /// </summary>
        public Vector3 GetMoveVector()
        {
            //移動を入力
            moveVec = new Vector3(Input.GetAxis("Horizontal") * accel, 0, Input.GetAxis("Vertical") * accel);
            return moveVec;
        }
        /// <summary>
        /// 正面方向の入力
        /// キーボード：マウスの位置(Y軸はプレイヤーの位置)
        /// </summary>
        /// <returns>
        /// </returns>>
        public Vector3 GetPleyerDirection()
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
                forwardDir = new Vector3(hit.point.x, PlayerObj.transform.position.y, hit.point.z);
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
            return Input.GetMouseButton(0);
        }
        // Use this for initialization
        void Start()
        {
        }
        // Update is called once per frame
        void Update()
        {
            //移動をオブジェクトに反映させる
            this.gameObject.transform.position += GetMoveVector();

            //マウスの方向を向くように回転
            this.PlayerObj.transform.rotation = Quaternion.LookRotation( GetPleyerDirection() - PlayerObj.transform.position);

            //射撃が入力されると起動
            if (GetShotButton())
            {
                //射撃方向(プレイヤーの正面方向)を入力
                //現行ではクリック中は毎フレーム射撃
                bulletForward = PlayerObj.transform.forward;
                Debug.Log(bulletForward + " の方向に発射");
            }
        }
    }
}
