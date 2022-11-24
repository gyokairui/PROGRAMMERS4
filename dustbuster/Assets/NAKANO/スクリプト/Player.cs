using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public static float moveSpeed = 10;       //プレイヤースピード
    public static int P_HP = 3;             //プレイヤーHP
    public static int P_Money = 0;          //お金
    public static int Player_LevelUP = 500;//プレイヤーのレベルアップに必要なお金
    public static int Score = 0;            //スコア
    public static int DustBOX = 0;          //掃除機の容量
    public static bool DustFULL = false;
    public string objName;
    public static bool P_V = false;
    public static bool GameOver_flg = false;
    bool P_LevelUP = false;
    public string sceneName;//シーン名inspectorで指定
    public string sceneName2;//シーン名inspectorで指定

    //ゲージ表示関係--------------
    public Slider slider;
    public Slider slider2;
    
    Slider hpSlider;
    //----------------------------

    private Rigidbody2D rb;
    private Vector2 movement;

    //サウンド関係
    AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        hpSlider = GetComponent<Slider>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//移動


        //ノーマル状態
        if(P_Money<Player_LevelUP&& Score>=5)//プレイヤーの容量
        {
              DustFULL = true;
        }

        //レベルアップ状態
        if (P_Money >= Player_LevelUP && Score >= 10)//プレイヤーの容量
        {
            DustFULL = true;
        }
    
        //レベルアップ状態
        if (P_Money>=Player_LevelUP)
        {
            moveSpeed = 15;//移動速度上昇
            //スライダーの最大値の設定
            slider.maxValue = 10;
        }
        if (P_Money >= Player_LevelUP&&P_LevelUP==false)
        {
            P_LevelUP = true;
            DustFULL = false;
        }

        //   //プレイヤー変数リセット----------------------------------------
        if (P_HP <= 0)//ガムに3回当たるとゲームーオーバー
        {
            P_HP = 3;
            DustBOX = 0;
            Score = 0;
            P_Money = 0;
            moveSpeed = 10;
            GameOver_flg = true;
            DustFULL = false;
            GameOver_flg = false;
            P_LevelUP = false;
            SceneManager.LoadScene(sceneName);
        }
        if (Input.GetKeyDown(KeyCode.R))//リスタートする
        {
            //プレイヤー変数リセット
            P_HP = 3;
            DustBOX = 0;
            Score = 0;
            P_Money = 0;
            moveSpeed = 10;
            GameOver_flg = true;
            DustFULL = false;
            GameOver_flg = false;
            P_LevelUP = false;
            SceneManager.LoadScene(sceneName2);
        }
        //-------------------------------------------------------------


        //プレイヤーの大きさを常に1に固定する
        Vector3 kero = new Vector3(1, 1, 1); 
        kero.x = 1; 
        gameObject.transform.localScale = kero; 
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()//移動
    {
        rb.AddForce(movement.normalized * moveSpeed);//移動
    }

  
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dust" && DustFULL == false)//ゴミに当たると...
        {
            audioSource.PlayOneShot(sound4);
            Score++;//掃除機ゲージのポイントが増える
            slider.value++;//掃除機ゲージの表示が増える
                           //アイテムに触れると振動する
            transform.DOShakeScale(
              duration: 0.2f,   // 演出時間
              strength: 0.2f  // シェイクの強さ
                              );
        }

        if (collision.gameObject.tag == "dustbox")//ゴミ箱に当たると...
        {
            slider.value = 0;//掃除機ゲージの表示が０になる
            DustFULL = false;
            slider2.value += Score;//ゴミ箱ゲージの表示が増える
            DustBOX += Score;//掃除機ポイントがゴミ箱に加算される
            audioSource.PlayOneShot(sound5);
            Score = 0;//掃除機ポイントがリセット
            P_V = true;
          
        }


        if (collision.gameObject.tag == "Gamu")//ガムに当たると...
        {
            P_Effect.Effect_flg = true;
            audioSource.PlayOneShot(sound5);
            P_HP--;
            transform.DOShakeScale(
duration: 0.3f,   // 演出時間
strength: 0.4f  // シェイクの強さ
);
        }

        //お金ヒット↓------------------------------------------------------------
        if (collision.gameObject.tag == "10")//１０円に当たると...
        {
            P_Money += 10;
            audioSource.PlayOneShot(sound2);
            Debug.Log(P_Money);//ポイントの表示
            transform.DOShakeScale(
    duration: 0.3f,   // 演出時間
    strength: 0.3f  // シェイクの強さ
);
        }
        if (collision.gameObject.tag == "100")//１００円に当たると...
        {
            P_Money += 100;
            audioSource.PlayOneShot(sound2);
            Debug.Log(P_Money);//ポイントの表示
            transform.DOShakeScale(
   duration: 0.3f,   // 演出時間
   strength: 0.3f  // シェイクの強さ
   );
        }
        if (collision.gameObject.tag == "500")//５００円に当たると...
        {
            P_Money += 500;
            audioSource.PlayOneShot(sound2);
            Debug.Log(P_Money);//ポイントの表示
            transform.DOShakeScale(
   duration: 0.3f,   // 演出時間
   strength: 0.3f  // シェイクの強さ
   );
        }
        //------------------------------------------------------------------------

    }
}
