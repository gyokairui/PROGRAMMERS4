using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeElapsedController : MonoBehaviour
{
    public Text textUI;

    void Start()
    {
        //コルーチンの実行
        StartCoroutine("Hoge");
    }

    private IEnumerator Hoge()
    {

        textUI.text = "○説明○";

        //数秒待つ
        yield return new WaitForSeconds(2.5f);

        //数秒待った後の処理
        textUI.text = "「WASD」：移動";
        //textUI.text = "「Enter」:";

        //数秒待つ
        yield return new WaitForSeconds(2.5f);

        //数秒待った後の処理
        textUI.text = "「R」　 :リスタート";

        //数秒待つ
        yield return new WaitForSeconds(2.5f);

        //数秒待った後にテキストを消す
        //テキスト閉じる方法わからん
        textUI.text = "";

    }
}