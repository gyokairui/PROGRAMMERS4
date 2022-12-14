using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class f_Player : MonoBehaviour
{
    public static float moveSpeed = 10;       //プレイヤースピード
    public static int P_HP = 3;             //プレイヤーHP
    public static int P_Money = 0;          //お金
    public static int Score = 0;            //スコア
    public static int DustBOX = 0;          //掃除機の容量
    public string objName;
    public static bool dustboxfrag = false;

    //位置
    public Transform target;
    public Vector3 offset;

    //ゲージ表示関係--------------
    public Slider slider;
    public Slider slider2;
    //----------------------------

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//移動
        offset = new Vector3(2, 2, 2);

        //transform.Rotate(new Vector3(0.0f, 0.0f, 0.1f));
        //Debug.Log(movement);
        // if(movement==1.0,0.0)


        if (DustBOX >= 3)//ゴミ箱ポイントが一定を超えるとクリア
        {
            Debug.Log("クリア");
        }

        if (P_HP <= 0)//ガムに3回当たるとゲームーオーバー
        {
            Debug.Log("ゲームオーバー");
        }

        if(dustboxfrag == false)
        {
            if (Input.GetButtonDown("RETURN"))
            {
                slider.value = 0;//掃除機ゲージの表示が０になる
                slider2.value += Score;//ゴミ箱ゲージの表示が増える
                DustBOX += Score;//掃除機ポイントがゴミ箱に加算される
                Score = 0;//掃除機ポイントがリセット
            }
        }
        
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dust")//ゴミに当たると...
        {
            Score++;//掃除機ゲージのポイントが増える
            Debug.Log(Score);//掃除機ポイントの表示
            slider.value++;//掃除機ゲージの表示が増える
        }

        //if (collision.gameObject.tag == "dustbox")//ゴミ箱に当たると...
        //{
        //    slider.value = 0;//掃除機ゲージの表示が０になる
        //    slider2.value += Score;//ゴミ箱ゲージの表示が増える
        //    DustBOX += Score;//掃除機ポイントがゴミ箱に加算される
        //    Score = 0;//掃除機ポイントがリセット
        //}


        if (collision.gameObject.tag == "Gamu")//ガムに当たると...
        {
            P_HP--;
        }

        //お金ヒット↓------------------------------------------------------------
        if (collision.gameObject.tag == "10")//１０円に当たると...
        {
            P_Money += 10;
            Debug.Log(P_Money);//ポイントの表示
        }
        if (collision.gameObject.tag == "100")//１００円に当たると...
        {
            P_Money += 100;
            Debug.Log(P_Money);//ポイントの表示
        }
        if (collision.gameObject.tag == "500")//５００円に当たると...
        {
            P_Money += 500;
            Debug.Log(P_Money);//ポイントの表示
        }
        //------------------------------------------------------------------------

        //objName = collision.gameObject.name;
        //Debug.Log(objName);


    }
}
