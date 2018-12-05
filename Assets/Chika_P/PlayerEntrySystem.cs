using UnityEngine;
using GamepadInput;
using System.Linq;

namespace RogueLike.Chikazawa
{
    /// <summary>
    /// エントリーシステム
    /// </summary>
    public class PlayerEntrySystem : MonoBehaviour
    {
        /// <summary>
        /// プレイヤーバインドデータ
        /// </summary>
        [SerializeField]
        private PlayerBindData _bindData;
        
        public int[] ControllerList = new int[4];//参加人数と使用コントローラーの状況
        public GameObject[] gameObjectsList = new GameObject[4];//スポーン（エントリー）したときのオブジェクト
        

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < ControllerList.Length; i++)
            {
                ControllerList[i] = -1;
            }
        }
        
        // Update is called once per frame
        void Update()
        {
            //キーボード
            //スペースキーでエントリー
            if (Input.GetKeyDown(KeyCode.Space) && !IsEntry(0))
            {

                //プレイヤー操作リストに追加
                if (ControllerList.Any(x => x == -1))
                {
                    var nowIdx = ControllerList.ToList().IndexOf(-1);
                    ControllerList[nowIdx] = 0;

                    gameObjectsList[ControllerList.ToList().IndexOf(-1)].SetActive(true);
                }
            }
            //Deleteで退出
            if (Input.GetKeyDown(KeyCode.Delete) && IsEntry(0))
            {
                //操作オブジェクトを非表示
                gameObjectsList[ControllerList.ToList().IndexOf(0)].SetActive(false);
                //プレイヤー操作リストから探し出して
                ControllerList[ControllerList.ToList().IndexOf(0)] = -1;
            }
            for (int i = 1; i < 5; i++)
            {
                //スタートボタンでエントリー
                if (GamePad.GetButtonDown(GamePad.Button.Start, (GamePad.Index)i) && !IsEntry(i))
                {
                    //プレイヤー操作リストに空きがあればそこに追加
                    if (ControllerList.Any(x => x == -1))
                    {
                        var nowIdx = ControllerList.ToList().IndexOf(-1);
                        ControllerList[nowIdx] = i;
                        gameObjectsList[nowIdx].SetActive(true);
                    }

                }
                //セレクト(Back)で退出
                if (GamePad.GetButtonDown(GamePad.Button.Back, (GamePad.Index)i) && IsEntry(i))
                {
                    //操作オブジェクトを非表示
                    gameObjectsList[ControllerList.ToList().IndexOf(i)].SetActive(false);
                    //プレイヤー操作リストから探し出して
                    ControllerList[ControllerList.ToList().IndexOf(i)] = -1;
                }
            }
            //保存
//            if (Input.GetKeyDown(KeyCode.KeypadEnter))
//            {
//                for (int i = 0; i < 4; i++)
//                {
//                    _bindData.PlayerEntries[i] = ControllerList[i];
//                }
//            }

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

        /// <summary>
        /// エントリーデータを保存
        /// </summary>
        public void Save()
        {
            for (int i = 0; i < 4; i++)
            {
                _bindData.PlayerEntries[i] = ControllerList[i];
            }
        }
    }
}