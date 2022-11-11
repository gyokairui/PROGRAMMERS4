using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]

public class f_Player2 : MonoBehaviour
{
    public static float moveSpeed = 10;       //プレイヤースピード
    public static int P_HP = 3;             //プレイヤーHP
    public static int P_Money = 0;          //お金
    public static int Score = 0;            //スコア
    public static int DustBOX = 0;          //掃除機の容量
    public static bool DustFULL = false;
    public string objName;
    public static bool P_V = false;

    //ゲージ表示関係--------------
    public Slider slider;
    public Slider slider2;
    //----------------------------

    private Rigidbody2D rb;
    private Vector2 movement;

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
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//移動

        if (Score >= 5)
        {
            DustFULL = true;
        }

        //if (DustBOX >= 3)//ゴミ箱ポイントが一定を超えるとクリア
        //{
        //    Debug.Log("クリア");
        //}

        if (P_HP <= 0)//ガムに3回当たるとゲームーオーバー
        {
            Debug.Log("ゲームオーバー");
        }

        //プレイヤーの大きさを1に固定する
        Vector3 kero = new Vector3(1, 1, 1);
        kero.x = 1;
        gameObject.transform.localScale = kero;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {

        rb.AddForce(movement.normalized * moveSpeed);//移動
        //transform.rotation = Quaternion.Slerp(transform.rotation,
        //Quaternion.LookRotation(-velocity),
        //applySpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dust" && DustFULL == false)//ゴミに当たると...
        {
            //audioSource.PlayOneShot(sound4);
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
            //audioSource.PlayOneShot(sound5);
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
            //audioSource.PlayOneShot(sound2);
            Debug.Log(P_Money);//ポイントの表示
            transform.DOShakeScale(
   duration: 0.3f,   // 演出時間
   strength: 0.3f  // シェイクの強さ
   );
        }
        if (collision.gameObject.tag == "500")//５００円に当たると...
        {
            P_Money += 500;
            //audioSource.PlayOneShot(sound2);
            Debug.Log(P_Money);//ポイントの表示
            transform.DOShakeScale(
   duration: 0.3f,   // 演出時間
   strength: 0.3f  // シェイクの強さ
   );
        }
        //------------------------------------------------------------------------

    }
}
