using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class f_Player : MonoBehaviour
{
    public static float moveSpeed = 50;//プレイヤースピード
    public static float applySpeed = 0.2f;
    public static int Score = 0;//スコア
    public float speed;

    public Slider slider;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //transform.Rotate(new Vector3(0.0f, 0.0f, 0.1f));

        Debug.Log(movement);

        // if(movement==1.0,0.0)

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

    //// 物理演算をしたい場合はFixedUpdateを使うのが一般的
    //void FixedUpdate()
    //{
    //    float horizontalKey = Input.GetAxis("Horizontal");

    //    //右入力で左向きに動く
    //    if (horizontalKey > 0)
    //    {
    //        rb.velocity = new Vector2(speed, rb.velocity.y);
    //    }
    //    //左入力で左向きに動く
    //    else if (horizontalKey < 0)
    //    {
    //        rb.velocity = new Vector2(-speed, rb.velocity.y);
    //    }
    //    //ボタンを話すと止まる
    //    else
    //    {
    //        rb.velocity = Vector2.zero;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dust")//ゴミに当たると...
        {
            Score++;
            Debug.Log(Score);
            slider.value++;
        }

    }
}
