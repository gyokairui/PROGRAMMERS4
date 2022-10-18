using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class f_Player : MonoBehaviour
{
    public static float moveSpeed = 50;//プレイヤースピード
    public static float applySpeed = 0.2f;
    public static int keyPlayer;
    public static int Score = 0;//スコア
    public static int Score2 = 0;//スコア2
    public float speed;
    public static int DustBOX = 0;
    public Slider slider_G; //ゴミ箱のゲージタンク
    public Slider slider_P; //プレイヤーのタンクゲージ

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //transform.Rotate(new Vector3(0.0f, 0.0f, 0.1f));

        if(tag == "dustbox")
        {
            if (Input.GetKeyDown("Return"))
            {
                slider_P.value = 0;
                slider_G.value += Score;
                DustBOX += Score;
                Score = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        rb.AddForce(movement.normalized * moveSpeed);
        //transform.rotation = Quaternion.Slerp(transform.rotation,
        //                                         Quaternion.LookRotation(-velocity),
        //                                         applySpeed);
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dust")//ゴミに当たると...
        {
            Score++;
            Debug.Log(Score);
            slider_P.value++;
        }


        //if (collision.gameObject.tag == "dustbox")//ゴミに当たると...
        //{
        //    //プレイヤーとゴミ箱が重なったときに、
        //    //スペースボタンを押したら吸い込んだゴミをゴミ箱に捨てる。
        //    //ゴミ箱に捨てたらプレイヤーのタンクゲージは減って、ゴミ箱のゲージは増える。
        //    if (Input.GetButton("SPACE"))
        //    {
        //        slider_G.value++; //ゴミ箱のゲージが増える
        //        slider_P.value--; //プレイヤーのタンクゲージが減る
        //    }
        //}
    }
   
}
