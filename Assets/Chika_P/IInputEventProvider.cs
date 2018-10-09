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
        bool GetShotButton();//攻撃
        Vector3 GetPleyerDirection(Vector3 plaryerPos);//正面方向
        Vector3 GetMoveVector();//移動
    }
}






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