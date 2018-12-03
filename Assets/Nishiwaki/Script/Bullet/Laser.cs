using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    Ray ray;        //レイ
    RaycastHit hit; //ヒットしたオブジェクト情報

    void Start()
    {

    }

    void Update()
    {
        //レイの設定
        ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        //レイキャスト（原点, 飛ばす方向, 衝突した情報, 長さ）
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //レイを可視化
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}
