using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeE_2 : MonoBehaviour
{
    public Text textUI;

    void Start()
    {
        //コルーチンの実行
        StartCoroutine("Hoge");
    }

    private IEnumerator Hoge()
    {

        textUI.text = "";

        //数秒待つ
        yield return new WaitForSeconds(7.5f);

        //数秒待った後の処理
        textUI.text = "ゴミを集めてゴミ箱に捨てよう！";
        //textUI.text = "「S」：下";
        //textUI.text = "「D」：右";
        //textUI.text = "「A」：左";

    }
}
