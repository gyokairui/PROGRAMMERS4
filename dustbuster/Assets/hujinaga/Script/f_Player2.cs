using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]

public class f_Player2 : MonoBehaviour
{
    public static float moveSpeed = 10;       //�v���C���[�X�s�[�h
    public static int P_HP = 3;             //�v���C���[HP
    public static int P_Money = 0;          //����
    public static int Score = 0;            //�X�R�A
    public static int DustBOX = 0;          //�|���@�̗e��
    public static bool DustFULL = false;
    public string objName;
    public static bool P_V = false;

    //�Q�[�W�\���֌W--------------
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
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//�ړ�

        if (Score >= 5)
        {
            DustFULL = true;
        }

        //if (DustBOX >= 3)//�S�~���|�C���g�����𒴂���ƃN���A
        //{
        //    Debug.Log("�N���A");
        //}

        if (P_HP <= 0)//�K����3�񓖂���ƃQ�[���[�I�[�o�[
        {
            Debug.Log("�Q�[���I�[�o�[");
        }

        //�v���C���[�̑傫����1�ɌŒ肷��
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

        rb.AddForce(movement.normalized * moveSpeed);//�ړ�
        //transform.rotation = Quaternion.Slerp(transform.rotation,
        //Quaternion.LookRotation(-velocity),
        //applySpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dust" && DustFULL == false)//�S�~�ɓ������...
        {
            //audioSource.PlayOneShot(sound4);
            Score++;//�|���@�Q�[�W�̃|�C���g��������
            slider.value++;//�|���@�Q�[�W�̕\����������
                           //�A�C�e���ɐG���ƐU������
            transform.DOShakeScale(
   duration: 0.2f,   // ���o����
   strength: 0.2f  // �V�F�C�N�̋���
   );
        }

        if (collision.gameObject.tag == "dustbox")//�S�~���ɓ������...
        {
            slider.value = 0;//�|���@�Q�[�W�̕\�����O�ɂȂ�
            DustFULL = false;
            slider2.value += Score;//�S�~���Q�[�W�̕\����������
            DustBOX += Score;//�|���@�|�C���g���S�~���ɉ��Z�����
            //audioSource.PlayOneShot(sound5);
            Score = 0;//�|���@�|�C���g�����Z�b�g
            P_V = true;

        }


        if (collision.gameObject.tag == "Gamu")//�K���ɓ������...
        {
            P_Effect.Effect_flg = true;
            audioSource.PlayOneShot(sound5);
            P_HP--;
            transform.DOShakeScale(
duration: 0.3f,   // ���o����
strength: 0.4f  // �V�F�C�N�̋���
);
        }

        //�����q�b�g��------------------------------------------------------------
        if (collision.gameObject.tag == "10")//�P�O�~�ɓ������...
        {
            P_Money += 10;
            audioSource.PlayOneShot(sound2);
            Debug.Log(P_Money);//�|�C���g�̕\��
            transform.DOShakeScale(
    duration: 0.3f,   // ���o����
    strength: 0.3f  // �V�F�C�N�̋���
);
        }
        if (collision.gameObject.tag == "100")//�P�O�O�~�ɓ������...
        {
            P_Money += 100;
            //audioSource.PlayOneShot(sound2);
            Debug.Log(P_Money);//�|�C���g�̕\��
            transform.DOShakeScale(
   duration: 0.3f,   // ���o����
   strength: 0.3f  // �V�F�C�N�̋���
   );
        }
        if (collision.gameObject.tag == "500")//�T�O�O�~�ɓ������...
        {
            P_Money += 500;
            //audioSource.PlayOneShot(sound2);
            Debug.Log(P_Money);//�|�C���g�̕\��
            transform.DOShakeScale(
   duration: 0.3f,   // ���o����
   strength: 0.3f  // �V�F�C�N�̋���
   );
        }
        //------------------------------------------------------------------------

    }
}
