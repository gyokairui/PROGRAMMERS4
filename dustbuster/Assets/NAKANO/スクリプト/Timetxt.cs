using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class Timetxt : MonoBehaviour
{

    public float Timea = 180;
    //float a = 0; 
    public GameObject score_object = null; // Textオブジェクト

    // 初期化
    void Start()
    {
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        Timea = Time.time;
        score_text.text = "Score:" + Timea;
        
    }
}