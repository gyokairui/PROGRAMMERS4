using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text textUI;

    void Start()
    {
        //コルーチンの実行
        StartCoroutine("Hoge");
    }

    private IEnumerator Hoge()
    {
        //数秒待つ
        yield return new WaitForSeconds(2.5f);

        //数秒待った後の処理
        textUI.text = "";
    }
}
