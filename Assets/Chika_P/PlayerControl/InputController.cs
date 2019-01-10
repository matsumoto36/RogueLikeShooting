using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

namespace DDD.Chikazawa.InputEventProvider
{  
    /// <summary>
     /// コントローラー入力
     /// </summary>
    public class InputController : PlayerInputProvider
    {
        private int _controller;

        public InputController(int Controller)
        {
            _controller = Controller;
        }


        public override Vector3 GetMoveVector()
        {
            Vector2 inputMove = GamePad.GetAxis(GamePad.Axis.LeftStick, (GamePad.Index)_controller, false);
            //左スティックで移動
            return new Vector3(inputMove.x,
                               0,
                               inputMove.y)
                               .normalized;
        }

        public override Vector3 GetPleyerDirection(Vector3 playerPos)
        {
            Vector2 inputDirection = GamePad.GetAxis(GamePad.Axis.RightStick, (GamePad.Index)_controller, false);

            //右スティックで方向入力
            //Playerの座標に入力を加算している
            return new Vector3(inputDirection.x,
                               0,
                               inputDirection.y)
                               .normalized
                               + playerPos;
        }

        public override bool GetShotButton()
        {
            //L1キーで攻撃
            return GamePad.GetButton(GamePad.Button.LeftShoulder,(GamePad.Index)_controller);
        }
        public override bool GetShotDown()
        {
            //L1押して起動
            return GamePad.GetButton(GamePad.Button.LeftShoulder, (GamePad.Index)_controller);
        }
        public override bool GetShotUp()
        {
            //L1離して起動
            return GamePad.GetButton(GamePad.Button.LeftShoulder, (GamePad.Index)_controller);
        }

        public override bool GetChangeBody()
        {
            return GamePad.GetButton(GamePad.Button.X, (GamePad.Index)_controller);
        }

    }
}