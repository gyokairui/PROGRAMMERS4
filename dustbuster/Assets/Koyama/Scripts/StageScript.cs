using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageScript : MonoBehaviour
{

    public int stage_num; // スコア変数
    public GameObject ni;

    // Use this for initialization
    void Start()
    {
        //現在のstage_numを呼び出す
        stage_num = PlayerPrefs.GetInt("SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //stage_numが２以上のとき、ステージ２を解放する。
        if (stage_num >= 2)
        {
            ni.SetActive(true);
        }
    }
}