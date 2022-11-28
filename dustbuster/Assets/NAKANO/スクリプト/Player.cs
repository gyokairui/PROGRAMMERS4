using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    //�v���C���[���
    public static float moveSpeed = 10;         //�v���C���[�X�s�[�h
    public static int P_HP = 3;                 //�v���C���[HP
    public static int P_Money = 0;              //����
    public static int DustBOX = 0;              //�S�~���̗e��
    public static int Score = 0;                //�|���@�̗e��
    public static bool DustFULL = false;�@�@    //�|���@�̗e�ʂ����^�����ǂ���
    public static bool GameOver_flg = false;    //�Q�[���I�[�o�[���Ă��邩
    public static bool P_LevelUP = false;       //�v���C���[�����x���A�b�v������


    public static int now_stage_number = 0;     //���݃v���C���̃X�e�[�W����i�P�Ȃ�stage�P�A�Q�Ȃ�stage�Q�ɂȂ�j
    public static int stage_1Point = 15;        //�X�e�[�W1�N���A�ɕK�v�ȃ|�C���g
    public static int stage_2Point = 25;        //�X�e�[�W2�N���A�ɕK�v�ȃ|�C���g

    public static int stage_1_LevelUP = 500;    //�X�e�[�W�P�Ńv���C���[�̃��x���A�b�v�ɕK�v�Ȃ���
    public static int stage_2_LevelUP = 1000;   //�X�e�[�W�Q�Ńv���C���[�̃��x���A�b�v�ɕK�v�Ȃ���

    //�V�[���֌W------------------------------------------
    public string sceneName;    //�Q�[���I�[�o�[
    public string sceneName2;   //���g���C�p
    public string sceneName3;   //�Q�[���N���A�[

    //�Q�[�W�\���֌W--------------
    public Slider slider;       //�v���C���[�Q�[�W
    public Slider slider2;      //�S�~���Q�[�W

    //----------------------------

    Slider hpSlider;
    private Rigidbody2D rb;
    private Vector2 movement;

    //�T�E���h�֌W
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
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//�ړ�


        //�m�[�}�����
        if(P_Money<stage_1_LevelUP && Score>=5)//�v���C���[�̗e��
        {
              DustFULL = true;//���^��
        }

        //���x���A�b�v���
        if (P_Money >= stage_1_LevelUP && Score >= 10)//�v���C���[�̗e��
        {
            DustFULL = true;//���^��
        }
    
        //���x���A�b�v���
        if (P_Money>= stage_1_LevelUP)
        {
            moveSpeed = 15;//�ړ����x�㏸
            //�X���C�_�[�̍ő�l�̐ݒ�
            slider.maxValue = 10;
        }

        if (P_Money >= stage_1_LevelUP && P_LevelUP==false)
        {
            //���^����ԂŃ��x���A�b�v����ƃS�~���z�����܂�Ȃ��s��C��
            P_LevelUP = true;
            DustFULL = false;
        }

        //   //�v���C���[�ϐ����Z�b�g----------------------------------------
        if (P_HP <= 0)//�K����3�񓖂���ƃQ�[���[�I�[�o�[
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
        if (Input.GetKeyDown(KeyCode.R))//���X�^�[�g����
        {
            //�v���C���[�ϐ����Z�b�g
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

        if(DustBOX>=20)//20�ȏ�ɂȂ�Ƒ��N���A��ʂɂȂ�
        {
            //�v���C���[�ϐ����Z�b�g
            P_HP = 3;
            DustBOX = 0;
            Score = 0;
            P_Money = 0;
            moveSpeed = 10;
            GameOver_flg = true;
            DustFULL = false;
            GameOver_flg = false;
            P_LevelUP = false;
            SceneManager.LoadScene(sceneName3);     
        }
        //-------------------------------------------------------------


        //�v���C���[�̑傫�������1�ɌŒ肷��i�V�F�C�N�ɂ��v���C���[�̑傫���ό`�΍�j
        Vector3 kero = new Vector3(1, 1, 1); 
        kero.x = 1; 
        gameObject.transform.localScale = kero; 
    }

    private void FixedUpdate()
    {
        MovePlayer();//�v���C���[�̈ړ�
    }

    private void MovePlayer()//�ړ�
    {
        rb.AddForce(movement.normalized * moveSpeed);//�ړ�
    }

  
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dust" && DustFULL == false)//�S�~�ɓ������...
        {
            audioSource.PlayOneShot(sound4);
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
            audioSource.PlayOneShot(sound5);
            Score = 0;//�|���@�|�C���g�����Z�b�g
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
            audioSource.PlayOneShot(sound2);
            Debug.Log(P_Money);//�|�C���g�̕\��
            transform.DOShakeScale(
   duration: 0.3f,   // ���o����
   strength: 0.3f  // �V�F�C�N�̋���
   );
        }
        if (collision.gameObject.tag == "500")//�T�O�O�~�ɓ������...
        {
            P_Money += 500;
            audioSource.PlayOneShot(sound2);
            Debug.Log(P_Money);//�|�C���g�̕\��
            transform.DOShakeScale(
   duration: 0.3f,   // ���o����
   strength: 0.3f  // �V�F�C�N�̋���
   );
        }
        //------------------------------------------------------------------------

    }
}
