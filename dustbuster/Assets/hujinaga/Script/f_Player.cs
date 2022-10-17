using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class f_Player : MonoBehaviour
{
    public static float moveSpeed = 50;//�v���C���[�X�s�[�h
    public static float applySpeed = 0.2f;
    public static int keyPlayer;
    public static int Score = 0;//�X�R�A
    public float speed;
    public Slider slider_G; //�S�~���̃Q�[�W�^���N
    public Slider slider_P; //�v���C���[�̃^���N�Q�[�W

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
        KeyPlayer();
    }

    private void MovePlayer()
    {
        rb.AddForce(movement.normalized * moveSpeed);
        //transform.rotation = Quaternion.Slerp(transform.rotation,
        //                                         Quaternion.LookRotation(-velocity),
        //                                         applySpeed);
    }

    private void KeyPlayer()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dust")//�S�~�ɓ������...
        {
            Score++;
            Debug.Log(Score);
            slider_P.value++;
        }

        if (collision.gameObject.tag == "dustbox")//�S�~�ɓ������...
        {
            //�v���C���[�ƃS�~�����d�Ȃ����Ƃ��ɁA
            //�X�y�[�X�{�^������������z�����񂾃S�~���S�~���Ɏ̂Ă�B
            //�S�~���Ɏ̂Ă���v���C���[�̃^���N�Q�[�W�͌����āA�S�~���̃Q�[�W�͑�����B
            if (Input.GetButton("SPACE"))
            {
                slider_G.value++; //�S�~���̃Q�[�W��������
                slider_P.value--; //�v���C���[�̃^���N�Q�[�W������
            }
        }
    }
}
