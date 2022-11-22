using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageScript : MonoBehaviour
{

    public int stage_num; // スコア変数
    public GameObject ni;
    public GameObject san;

    // Use this for initialization
    void Start()
    {
        //現在のstage_numを呼び出す
        stage_num = PlayerPrefs.GetInt("SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //stage_numが２以上のとき、ステージ２を解放する。以下同様
        if (stage_num >= 2)
        {
            ni.SetActive(true);
        }

        if (stage_num >= 3)
        {
            san.SetActive(true);
        }
    }
}