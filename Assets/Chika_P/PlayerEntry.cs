using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

/// <summary>
/// エントリーシステム
/// </summary>
public class PlayerEntry : MonoBehaviour {

    public static List<int> Players;//参加人数と使用コントローラーの状況
    [SerializeField]
    GameObject DefaultBody;//初期武器
    testP test; //番号振り分けの反映先

	// Use this for initialization
	void Start () {
        Players = new List<int>();
        test = DefaultBody.GetComponent<testP>();
    }

    // Update is called once per frame
    void Update () {
        //キーボード
        //スペースキーでエントリー
        if (Input.GetKeyDown(KeyCode.Space) && !IsEntry(0))
        {
            //コントローラーの番号を振り分け
            test.ControllerNo = 0;
            //プレイヤー操作リストに追加j
            Players.Add(0);
            //実際のオブジェクトをデフォルトの状態で生成
            GameObject KeyPlayer = Instantiate(DefaultBody);
            //コントローラーの番号が名前
            KeyPlayer.name = "Player" + 0;
        }
        //Deleteで退出
        if (Input.GetKeyDown(KeyCode.Delete) && IsEntry(0))
        {
            //操作オブジェクトを削除
            Destroy(GameObject.Find("Player" + 0));
            //プレイヤー操作リストから探し出して削除
            Players.Remove(0);
        }
        for (int i = 1; i < 5; i++)
        {
            //スタートボタンでエントリー
            if (GamePad.GetButtonDown(GamePad.Button.Start, (GamePad.Index)i) && !IsEntry(i))
            {
                {
                    test.ControllerNo = i;
                    Players.Add(i);
                    GameObject ConPlayer = Instantiate(DefaultBody);
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
                    Players.Remove(i);
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
        foreach (var item in Players)
        {
            if (item == Controller)
                return true;
        }
        return false;
    }

}
