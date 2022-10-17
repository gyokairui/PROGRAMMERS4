using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public static float moveSpeed=10;//プレイヤースピード
    public static float applySpeed = 0.2f; 
    public static int Score = 0;//スコア
    public static int DustBOX = 0;
    public static bool P_dustflag = false;


    public Slider slider;
    public Slider slider2;

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

        //Debug.Log(movement);

       // if(movement==1.0,0.0)

        if(DustBOX == 3)
        {
            Debug.Log("クリア");
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
            slider.value++;
            P_dustflag = true;
        }

        if (collision.gameObject.tag == "dustbox")//ゴミ箱に当たると...
        {
            slider.value = 0;
            slider2.value += Score;
            DustBOX += Score;
            Score = 0;
            
        }

    }
}
