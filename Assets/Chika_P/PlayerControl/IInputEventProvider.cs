using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Chikazawa
{
    /// <summary>
    /// コントローラーの検知内容
    /// </summary>
    public interface IInputEventProvider 
    {
        /// <summary>
        /// 攻撃(射撃)連射フラグ
        /// キーボード：左クリック ／
        /// コントローラー：L１ボタン
        /// </summary>
        /// <returns></returns>
        bool GetShotButton(int controllerNo);
        /// <summary>
        /// 攻撃タメフラグ
        /// </summary>
        /// <returns></returns>
        bool GetShotDown(int controllerNo);
        /// <summary>
        /// 攻撃放出フラグ
        /// </summary>
        /// <returns></returns>
        bool GetShotUp(int controllerNo);
        /// <summary>
        /// 正面方向の入力
        /// キーボード：マウス ／
        /// コントローラー：右スティック
        /// </summary>
        /// <param name="plaryerPos"></param>
        /// <returns></returns>
        Vector3 GetPleyerDirection(Vector3 plaryerPos, int controllerNo);
        /// <summary>
        /// 移動の入力
        /// キーボード：WASDキー or 矢印キー ／
        /// コントローラー：左スティック
        /// </summary>
        /// <returns></returns>
        Vector3 GetMoveVector(int controllerNo);
    }
}






//メモ
//仮プレイヤー入力　クラス分け構造
//public class P
//{
//    インターフェースを取得
//    I inputInterface;
//    void Start()
//    {   取得したインターフェースを初期化
//        inputInterface = new InputPlayer();
//    }
//    void Update()
//    {   インターフェースを渡すクラスに設定されている入力があったら行動(起動条件)
//        if (inputInterface.GetAttackButton())
//        {
//        }
//    }
//}
//
//public interface I
//{
//    入力判定を検知する(検知内容)
//    bool GetAttackButton();
//}
//入力があったことをインターフェースに渡すクラス
//public class InputPlayer : I
//{
//    検知する入力(検知内容)
//    public bool GetAttackButton()
//    {
//        左クリックで起動するように返す(起動条件)
//        return Input.GetMouseButtonDown(0);
//    }
//}