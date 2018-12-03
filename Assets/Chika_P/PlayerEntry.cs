using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GamepadInput;

using RogueLike.Chikazawa;
using RogueLike.Chikazawa.InputEventProvider;
using RogueLike.Matsumoto;

/// <summary>
/// エントリーシステム
/// </summary>
public class PlayerEntry : MonoBehaviour
{
    public List<int> ControllerList;//参加人数と使用コントローラーの状況
    public CharacterSpawner Spawner;
    public PlayerList PlayerList;
    //GameObject DefaultBody;         //スポーン（エントリー）したときのオブジェクト


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
        if (Input.GetKeyDown(KeyCode.Space) && !IsEntry(-1))
        {

            //プレイヤー操作リストに追加
            ControllerList.Add(-1);
            //ControllerListが4つ以上入っていれば削除する
            if (ControllerList.IndexOf(-1) >= 5)
            {
                ControllerList.Remove(-1);
                return;
            }
            Spawner.Spawn();
        }
        //Deleteで退出
        if (Input.GetKeyDown(KeyCode.Delete) && IsEntry(-1))
        {
            ////操作オブジェクトを削除
            //Destroy(GameObject.Find("Player" + -1));
            ////プレイヤー操作リストから探し出して削除
            //ControllerList.Remove(-1);
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
                }
                Spawner.Spawn();
                //Players.InputEventProvider = new InputController(i);

            }
            //セレクト(Back)で退出
            if (GamePad.GetButtonDown(GamePad.Button.Back, (GamePad.Index)i) && IsEntry(i))
            {
                ////操作オブジェクトを名前で検索して削除
                //Destroy(GameObject.Find("Player" + i));
                ////プレイヤー操作リストから探し出して削除
                //ControllerList.Remove(i);
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