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
        //IInputEventProvider

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            //getInput.moveVec = new Vector3(Input.GetAxis("Horizontal") * getInput.accel, 0, Input.GetAxis("Vertical") * getInput.accel);
            
        }
    }
}
