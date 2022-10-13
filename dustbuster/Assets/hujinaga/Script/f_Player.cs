using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class f_Player : MonoBehaviour
{
    public static float moveSpeed = 50;//�v���C���[�X�s�[�h
    public static float applySpeed = 0.2f;
    public static int Score = 0;//�X�R�A
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

    //// �������Z���������ꍇ��FixedUpdate���g���̂���ʓI
    //void FixedUpdate()
    //{
    //    float horizontalKey = Input.GetAxis("Horizontal");

    //    //�E���͂ō������ɓ���
    //    if (horizontalKey > 0)
    //    {
    //        rb.velocity = new Vector2(speed, rb.velocity.y);
    //    }
    //    //�����͂ō������ɓ���
    //    else if (horizontalKey < 0)
    //    {
    //        rb.velocity = new Vector2(-speed, rb.velocity.y);
    //    }
    //    //�{�^����b���Ǝ~�܂�
    //    else
    //    {
    //        rb.velocity = Vector2.zero;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dust")//�S�~�ɓ������...
        {
            Score++;
            Debug.Log(Score);
            slider.value++;
        }

    }
}
