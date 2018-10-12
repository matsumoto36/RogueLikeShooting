using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Chikazawa.InputEventProvider
{
    /// <summary>
    /// キーボード入力
    /// </summary>
    public class InputKeyBoard : PlayerInputProvider
    {
        public Vector3 moveVec;        //移動方向
        public Vector3 forwardDir;     //正面方向
        public bool GetShot;           //攻撃入力

        public override Vector3 GetMoveVector()
        {

            //キーボード
            moveVec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            return moveVec;
        }

        public override Vector3 GetPleyerDirection(Vector3 playerPos)
        {
            Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseHit;
            if (Physics.Raycast(mousePos, out mouseHit, Mathf.Infinity))
            {
                //マウスの方向を向く、高さはプレイヤーのY軸に依存している
                forwardDir = new Vector3(mouseHit.point.x, playerPos.y, mouseHit.point.z);
            }

            return forwardDir;
        }

        public override bool GetShotButton()
        {
            GetShot = Input.GetMouseButton(0);

            return GetShot;
        }
    }
}
