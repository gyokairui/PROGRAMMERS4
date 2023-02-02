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
            //timeText.text = "タイムアップ";

            if (Player.now_stage_number==1)
            {
                //ステージ１の場合
                if (Player.DustBOX >= Player.stage_1_clearPoint)//ゴミが一定以上あるとクリア
                {
                    Player.Game_Clear_Score1 = Player.DustBOX;
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

            if (Player.now_stage_number == 2)
            {
                //ステージ１の場合
                if (Player.DustBOX >= Player.stage_2_clearPoint)//ゴミが一定以上あるとクリア
                {
                    Player.Game_Clear_Score2 = Player.DustBOX;
                    Player.Player_reset();//プレイヤー変数リセット
                    SceneManager.LoadScene(SceneName2);

                    Player.Rank += Player.Game_Clear_Score1 + Player.Game_Clear_Score2;

                    if (Player.Rank >= 45 && 50 > Player.Rank)
                    {
                        Debug.Log("E");
                    }
                    if (Player.Rank >= 50 && 55 > Player.Rank)
                    {
                        Debug.Log("B");
                    }
                    if (Player.Rank >= 55 && 58 > Player.Rank)
                    {
                        Debug.Log("A");
                    }
                    if (Player.Rank >= 58)
                    {
                        Debug.Log("S");
                    }
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
}