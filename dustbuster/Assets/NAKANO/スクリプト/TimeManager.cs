using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeManager : MonoBehaviour
{
    //カウントダウン
    public float countdown = 5.0f;

    //時間を表示するText型の変数
    public Text timeText;
    public string sceneName1;//シーン名inspectorで指定
    public string sceneName2;//シーン名inspectorで指定
    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1") + "秒";

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "タイムアップ";
            if(Player.Score>=20)//ゴミが一定以上あるとクリア
            {
                Player.P_HP = 3;
                Player.DustBOX = 0;
                Player.Score = 0;
                Player.P_Money = 0;
                Player.GameOver_flg = true;
                Player.DustFULL = false;
                Player.GameOver_flg = false;
                SceneManager.LoadScene(sceneName1);
            }

            if (Player.Score < 20)//ゴミが一定以上無いとゲームオーバー
            {
                Player.P_HP = 3;
                Player.DustBOX = 0;
                Player.Score = 0;
                Player.P_Money = 0;
                Player.GameOver_flg = true;
                Player.DustFULL = false;
                Player.GameOver_flg = false;
                SceneManager.LoadScene(sceneName2);
            }
        }

    }
}