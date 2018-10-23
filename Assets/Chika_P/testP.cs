﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Chikazawa;
using RogueLike.Chikazawa.InputEventProvider;
using GamepadInput;

public class testP : MonoBehaviour
{
    IInputEventProvider eventProvider;
    [SerializeField]
    GameObject PlayerObj;   //操作するプレイヤー
    [SerializeField]
    float accel;        //加速度

    // Use this for initialization
    void Start ()
    {
        eventProvider =  new InputController();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //移動をオブジェクトに反映させる
        this.gameObject.transform.position += eventProvider.GetMoveVector();

        //コントローラーの場合、右スティックの入力が無いときは動作しない
        if (eventProvider.GetPleyerDirection(PlayerObj.transform.position) - PlayerObj.transform.position != Vector3.zero)
        {
            //マウスor右スティックの方向を向くように回転・右スティックの入力を反映
            this.gameObject.transform.rotation
                = Quaternion.LookRotation(eventProvider.GetPleyerDirection(PlayerObj.transform.position) - PlayerObj.transform.position).normalized;
        }
        //射撃が入力されると起動
        if (eventProvider.GetShotButton())
        {
            //射撃方向(プレイヤーの正面方向)を入力
            //現行ではクリック中は毎フレーム射撃
            Debug.Log(PlayerObj.transform.forward + " の方向に発射");
        }
    }
}
