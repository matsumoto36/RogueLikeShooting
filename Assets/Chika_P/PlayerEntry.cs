using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

/// <summary>
/// エントリーシステム
/// </summary>
public class PlayerEntry : MonoBehaviour {

    public List<int> Players;//参加人数と使用コントローラーの状況
    [SerializeField]
    GameObject DefaultBody;//初期武器
    testP test;

	// Use this for initialization
	void Start () {
        Players = new List<int>();
        test = DefaultBody.GetComponent<testP>();
    }

    // Update is called once per frame
    void Update () {
        //スペースキーでエントリー
        if (Input.GetKeyDown(KeyCode.Space) && !IsEntry(0))
        {
            test.ControllerNo = 0;
            Players.Add(0);
            Instantiate(DefaultBody);
        }
        for (int i = 1; i < 5; i++)
        {
            //スタートボタンでエントリー
            if (GamePad.GetButtonDown(GamePad.Button.Start, (GamePad.Index)i) && !IsEntry(i))
            {
                {
                    test.ControllerNo = i;
                    Players.Add(i);
                    Instantiate(DefaultBody); 
                }
            }
        }
    }
    bool IsEntry(int Controller)
    {
        foreach (var item in Players)
        {
            if (item == Controller)
                return true;
        }
        return false;
    }

}
