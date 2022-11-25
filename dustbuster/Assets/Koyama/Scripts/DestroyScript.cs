using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public int stage_n; // スコア変数
    public GameObject b;

    // Start is called before the first frame update
    void Start()
    {
        stage_n = PlayerPrefs.GetInt("SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //stage_numが２以上のとき、ステージ２を解放する。
        if (stage_n >= 2)
        {
            Destroy(gameObject);
        }
    }
}
