using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeManager : MonoBehaviour
{
    //カウントダウン
    public float countdown = 60.0f;

    //時間を表示するText型の変数
    public Text timeText;

    //シーン関係-----------------------------------------------
    public string SceneName1;//ゲームオーバー
    public string SceneName2;//ゲームクリアー
    //----------------------------------------------------

    void start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1") + "秒";

        //countdownが0以下になったとき
        //ステータス初期化
        if (countdown <= 0)
        {
            timeText.text = "タイムアップ";
            if(Player.DustBOX>=15)//ゴミが一定以上あるとクリア
            {
                Player.Player_reset();//プレイヤー変数リセット
                SceneManager.LoadScene(SceneName2);
                
            }
            //ゴミが一定以上無いとゲームオーバー
            else
            {
                Player.Player_reset();//プレイヤー変数リセット
                SceneManager.LoadScene(SceneName1);
               
            }
        }

    }
}