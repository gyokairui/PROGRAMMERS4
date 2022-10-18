using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public static float moveSpeed=10;       //�v���C���[�X�s�[�h
    public static int P_HP = 3;             //�v���C���[HP
    public static int P_Money = 0;          //����
    public static int Score = 0;            //�X�R�A
    public static int DustBOX = 0;          //�|���@�̗e��
    public string objName;

    //�Q�[�W�\���֌W--------------
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
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//�ړ�

        //transform.Rotate(new Vector3(0.0f, 0.0f, 0.1f));
        //Debug.Log(movement);
       // if(movement==1.0,0.0)


        if(DustBOX >= 3)//�S�~���|�C���g�����𒴂���ƃN���A
        {
            Debug.Log("�N���A");
        }
            
        if(P_HP<=0)//�K����3�񓖂���ƃQ�[���[�I�[�o�[
        {
            Debug.Log("�Q�[���I�[�o�[");
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.AddForce(movement.normalized * moveSpeed);//�ړ�
        //transform.rotation = Quaternion.Slerp(transform.rotation,
        //Quaternion.LookRotation(-velocity),
        //applySpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dust")//�S�~�ɓ������...
        {
            Score++;//�|���@�Q�[�W�̃|�C���g��������
            Debug.Log(Score);//�|���@�|�C���g�̕\��
            slider.value++;//�|���@�Q�[�W�̕\����������
        }

        if (collision.gameObject.tag == "dustbox")//�S�~���ɓ������...
        {
            slider.value = 0;//�|���@�Q�[�W�̕\�����O�ɂȂ�
            slider2.value += Score;//�S�~���Q�[�W�̕\����������
            DustBOX += Score;//�|���@�|�C���g���S�~���ɉ��Z�����
            Score = 0;//�|���@�|�C���g�����Z�b�g
        }


        if (collision.gameObject.tag == "Gamu")//�K���ɓ������...
        {
            P_HP--;
        }

        //�����q�b�g��------------------------------------------------------------
        if (collision.gameObject.tag == "10")//�P�O�~�ɓ������...
        {
            P_Money += 10;
            Debug.Log(P_Money);//�|�C���g�̕\��
        }
        if (collision.gameObject.tag == "100")//�P�O�O�~�ɓ������...
        {
            P_Money += 100;
            Debug.Log(P_Money);//�|�C���g�̕\��
        }
        if (collision.gameObject.tag == "500")//�T�O�O�~�ɓ������...
        {
            P_Money += 500;
            Debug.Log(P_Money);//�|�C���g�̕\��
        }
        //------------------------------------------------------------------------

        //objName = collision.gameObject.name;
        //Debug.Log(objName);


    }
}
