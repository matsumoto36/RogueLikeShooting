using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

namespace RogueLike.Chikazawa.InputEventProvider
{  
    /// <summary>
     /// コントローラー入力
     /// </summary>
    public class InputController : PlayerInputProvider
    {
        bool dead = false;  //deadPointは有効

        public override Vector3 GetMoveVector()
        {
            //左スティックで移動
            return new Vector3(GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One, dead).x,
                               0,
                               GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One, dead).y)
                               .normalized;
        }

        public override Vector3 GetPleyerDirection(Vector3 playerPos)
        {
            //右スティックで方向入力
            //Playerの座標に入力を加算している
            return new Vector3(GamePad.GetAxis(GamePad.Axis.RightStick, GamePad.Index.One, dead).x,
                               0,
                               GamePad.GetAxis(GamePad.Axis.RightStick, GamePad.Index.One, dead).y)
                               .normalized
                               + playerPos;
        }

        public override bool GetShotButton()
        {
            //L1キーで攻撃
            return GamePad.GetButton(GamePad.Button.LeftShoulder,GamePad.Index.One);
        }
        public override bool GetShotDown()
        {
            //左クリック押して起動
            return GamePad.GetButtonDown(GamePad.Button.LeftShoulder, GamePad.Index.One);
        }
        public override bool GetShotUp()
        {
            //左クリック離して起動
            return GamePad.GetButtonUp(GamePad.Button.LeftShoulder, GamePad.Index.One);
        }

    }
}