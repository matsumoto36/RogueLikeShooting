using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Chikazawa.InputEventProvider
{  
    /// <summary>
     /// コントローラー入力
     /// </summary>
    public class InputController : PlayerInputProvider
    {
        public override Vector3 GetMoveVector()
        {
            //左スティックで移動
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        }

        public override Vector3 GetPleyerDirection(Vector3 playerPos)
        {
            //右スティックで方向入力(非入力時は奥を向く)
            //Playerの座標に入力を加算している
            return new Vector3(Input.GetAxisRaw("R_Horizontal") + playerPos.x, playerPos.y, Input.GetAxisRaw("R_Vertical") + playerPos.z);
        }

        public override bool GetShotButton()
        {
            //L1キーで攻撃
            return Input.GetButton("Shot");
        }
        public override bool GetShotDown()
        {
            //左クリック押して起動
            return Input.GetButtonDown("Shot");
        }
        public override bool GetShotUp()
        {
            //左クリック離して起動
            return Input.GetButtonUp("Shot");
        }

    }
}