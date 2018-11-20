using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

using RogueLike.Chikazawa;
using RogueLike.Matsumoto;

/// <summary>
/// エントリーシステム
/// </summary>
public class PlayerEntry : MonoBehaviour
{
        
    public static List<int> ControllerList;//参加人数と使用コントローラーの状況
     int[] bindID = new int[4];
    public PlayerCore Players { get; private set; }

    [SerializeField]
    GameObject DefaultBody;         //スポーン（エントリー）したときのオブジェクト

    // Use this for initialization
    void Start()
    {
        ControllerList = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        //キーボード
        //スペースキーでエントリー
        if (Input.GetKeyDown(KeyCode.Space) && !IsEntry(0))
        {

            //プレイヤー操作リストに追加
            ControllerList.Add(0);
            //ControllerListが4つ以上入っていれば削除する
            if (ControllerList.IndexOf(0) >= 5)
            {
                ControllerList.Remove(0);
                return;
            }
            //実際のオブジェクトをデフォルトの状態で生成
            GameObject KeyPlayer = Instantiate(DefaultBody);

            //bindIDにPlayerCoreを紐づけする
            bindID[ControllerList.IndexOf(0)] = Players.ID;
            //IDの場所が名前
            KeyPlayer.name = "Player" + ControllerList.IndexOf(0) + 1;
        }
        //Deleteで退出
        if (Input.GetKeyDown(KeyCode.Delete) && IsEntry(0))
        {
            //操作オブジェクトを削除
            Destroy(GameObject.Find("Player" + 0));
            //プレイヤー操作リストから探し出して削除
            ControllerList.Remove(0);
        }
        for (int i = 1; i < 5; i++)
        {
            //スタートボタンでエントリー
            if (GamePad.GetButtonDown(GamePad.Button.Start, (GamePad.Index)i) && !IsEntry(i))
            {
                {
                    ControllerList.Add(i);
                    //ControllerListが4つ以上入っていれば削除する
                    if (ControllerList.IndexOf(i) >= 5)
                    {
                        ControllerList.Remove(i);
                        return;
                    }

                    GameObject ConPlayer = Instantiate(DefaultBody);

                    bindID[ControllerList.IndexOf(i)] = Players.ID;

                    ConPlayer.name = "Player" + i;
                }
            }
            //セレクト(Back)で退出
            if (GamePad.GetButtonDown(GamePad.Button.Back, (GamePad.Index)i) && IsEntry(i))
            {
                {
                    //操作オブジェクトを名前で検索して削除
                    Destroy(GameObject.Find("Player" + i));
                    //プレイヤー操作リストから探し出して削除
                    ControllerList.Remove(i);
                }
            }
        }
    }
    /// <summary>
    /// コントローラーの参加状態の確認 
    /// </summary>
    /// <param name="Controller">入力コントローラー</param>
    /// <returns></returns>
    bool IsEntry(int Controller)
    {
        //リスト内に入力コントローラーがあるか確認
        foreach (var item in ControllerList)
        {
            if (item == Controller)
                return true;
        }
        return false;
    }

}