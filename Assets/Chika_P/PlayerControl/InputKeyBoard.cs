using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDD.Chikazawa.InputEventProvider
{
    /// <summary>
    /// キーボード入力
    /// </summary>
    public class InputKeyBoard : PlayerInputProvider
    {
        Vector3 forwardDir;     //正面方向


        public override Vector3 GetMoveVector()
        {
            //WASDキーで移動
            return new Vector3(
                Input.GetAxisRaw("Keyboard_XAxis"),
                0,
                Input.GetAxisRaw("Keyboard_YAxis"))
                .normalized;
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
            //左クリックで攻撃
            return Input.GetMouseButton(0);
        }
        public override bool GetShotDown()
        {
            //左クリック押して起動
            return Input.GetMouseButtonDown(0);
        }
        public override bool GetShotUp()
        {
            //左クリック離して起動
            return Input.GetMouseButtonUp(0);
        }
        public override bool GetChangeBody()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }

    }
}
