using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーで共有のHPを提供する
/// </summary>
public class PlayerHPProvider : MonoBehaviour {

	public int MaxHP { get; set; }

	public int NowHP { get; set; }

}
