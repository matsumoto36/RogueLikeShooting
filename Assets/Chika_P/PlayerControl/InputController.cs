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
        public override Vector3 GetMoveVector(int controllerNo)
        {
            Vector2 inputMove = GamePad.GetAxis(GamePad.Axis.LeftStick, (GamePad.Index)controllerNo, false);
            //左スティックで移動
            return new Vector3(inputMove.x,
                               0,
                               inputMove.y)
                               .normalized;
        }

        public override Vector3 GetPleyerDirection(Vector3 playerPos, int controllerNo)
        {
            Vector2 inputDirection = GamePad.GetAxis(GamePad.Axis.RightStick, (GamePad.Index)controllerNo, false);

            //右スティックで方向入力
            //Playerの座標に入力を加算している
            return new Vector3(inputDirection.x,
                               0,
                               inputDirection.y)
                               .normalized
                               + playerPos;
        }

        public override bool GetShotButton(int controllerNo)
        {
            //L1キーで攻撃
            return GamePad.GetButton(GamePad.Button.LeftShoulder,(GamePad.Index)controllerNo);
        }
        public override bool GetShotDown(int controllerNo)
        {
            //L1押して起動
            return GamePad.GetButton(GamePad.Button.LeftShoulder, (GamePad.Index)controllerNo);
        }
        public override bool GetShotUp(int controllerNo)
        {
            //L1離して起動
            return GamePad.GetButton(GamePad.Button.LeftShoulder, (GamePad.Index)controllerNo);
        }

    }
}