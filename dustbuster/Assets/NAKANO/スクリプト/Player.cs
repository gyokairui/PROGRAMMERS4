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
    public bool isDamage = false;               //�_���[�Weffect�p

    //�����N�t���p���[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�@�S�~�̐���MAX58
    public static int Rank = 0;                  //��������S�~�̗ʂŃ����N�t������@�S�T��E�@�T�O��B�@�T�T��A�@�T�W��S�@
    public static int Game_Clear_Score1 = 0;     //�Q�[���N���A��̃����N���p�@�X�e�[�W1
    public static int Game_Clear_Score2 = 0;     //�Q�[���N���A��̃����N���p�@�X�e�[�W�Q


    //�X�e�[�W���ƂɈقȂ�ϐ���-------------------
    public static int now_stage_number = 0;        //���݃v���C���̃X�e�[�W����i�P�Ȃ�stage�P�A�Q�Ȃ�stage�Q�ɂȂ�j

    public static int stage_1_clearPoint = 15;     //�X�e�[�W1�N���A�ɕK�v�ȃ|�C���g
    public static int stage_1_MAXPoint = 20;       //�X�e�[�W1�̗����Ă邷�ׂĂ̂��݂̗�
    public static int stage_1_Money = 0;

    public static int stage_2_clearPoint = 30;     //�X�e�[�W2�N���A�ɕK�v�ȃ|�C���g
    public static int stage_2_MAXPoint = 38;       //�X�e�[�W2�̗����Ă邷�ׂĂ̂��݂̗�

    public static int stage_1_LevelUP = 500;       //�X�e�[�W�P�Ńv���C���[�̃��x���A�b�v�ɕK�v�Ȃ���
    public static int stage_2_LevelUP = 600;       //�X�e�[�W�Q�Ńv���C���[�̃��x���A�b�v�ɕK�v�Ȃ���

    public static bool stage_1_clearFLG = false;   //�X�e�[�W1�N���A�t���O
    public static bool stage_2_clearFLG = false;   //�X�e�[�W2�N���A�t���O
                                                   //------------------------------------------------

    //���̋@�\��
    public int countdown = 0;

    //���Ԃ�\������Text�^�̕ϐ�
    public Text MoneyText;

    //�V�[���֌W------------------------------------------
    public string sceneName;    //�Q�[���I�[�o�[
    public string sceneName2;   //���g���C�p
    public string sceneName3;   //�Q�[���N���A�[

    //�Q�[�W�\���֌W--------------
    public Slider slider;       //�v���C���[�Q�[�W
    public Slider slider2;      //�S�~���Q�[�W
    public Image sliderImage; 
    public Image sliderImage2; 
    //----------------------------

    Slider hpSlider;
    private Rigidbody2D rb;
    public SpriteRenderer sp;
    private Vector2 movement;

    //�T�E���h�֌W
    AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        hpSlider = GetComponent<Slider>();
        audioSource.PlayOneShot(sound3);
    }

    void Update()
    {
        if (isDamage == true)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 40));
            sp.color = new Color(1f, 1f, 1f, level);
            StartCoroutine(OnDamage());
        }

        if (DustFULL == true)
            sliderImage.color = new Color32(255, 0, 0, 255);
        else
            sliderImage.color = new Color32(0, 0, 255, 255);

        //�N���A�|�C���g���҂��ƃQ�[�W�̐F���ς��
        if (now_stage_number == 1 && stage_1_clearPoint <= DustBOX) 
        {
            sliderImage2.color = new Color32(255, 255, 0, 255);
        }

        if (now_stage_number == 2 && stage_2_clearPoint <= DustBOX) 
        {
            sliderImage2.color = new Color32(255, 255, 0, 255);
        }

        //�c��̂�����\������
        //MoneyText.text = countdown.ToString("f1") + "��";

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//�ړ�

        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))//�ړ������Ɍ���
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))//�ړ������Ɍ���
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

            if (now_stage_number==2)//�X�e�[�W�Q�Ȃ�S�~���̗e�ʂ𑝂₷
        {
            //�X���C�_�[�̍ő�l�̐ݒ�
            slider2.maxValue = stage_2_MAXPoint;
        }

        //�m�[�}�����------------------------------------------------------------------------
        //�X�e�[�W1�̏ꍇ
        if (now_stage_number==1&&P_Money<stage_1_LevelUP && Score>=5)//�v���C���[�̗e��
        {
              DustFULL = true;//���^���t���O
        }
        //���x���A�b�v���
        if (now_stage_number==1&&P_Money >= stage_1_LevelUP && Score >= 10)//�v���C���[�̗e��
        {
            DustFULL = true;//���^���t���O
        }

        //�X�e�[�W2�̏ꍇ
        //�m�[�}�����
        if (now_stage_number == 2 && P_Money < stage_2_LevelUP && Score >= 5)//�v���C���[�̗e��
        {
            DustFULL = true;//���^���t���O
        }
        //���x���A�b�v���
        if (now_stage_number == 2 && P_Money >= stage_2_LevelUP && Score >= 15)//�v���C���[�̗e��
        {
            DustFULL = true;//���^���t���O
        }
        //-----------------------------------------------------------------------------------


        //���x���A�b�v����--------------------------------------------
        //�X�e�[�W�P�̏ꍇ
        if (now_stage_number==1&&P_Money>= stage_1_LevelUP)
        {
            moveSpeed = 14;//�ړ����x�㏸
            //�X���C�_�[�̍ő�l�̐ݒ�
            slider.maxValue = 10;
        }
        //�X�e�[�W�Q�̏ꍇ
        if (now_stage_number == 2 && P_Money >= stage_2_LevelUP)
        {
            moveSpeed = 15;//�ړ����x�㏸
            //�X���C�_�[�̍ő�l�̐ݒ�
            slider.maxValue = 15;
        }

        //���^����ԂŃ��x���A�b�v����ƃS�~���z�����܂�Ȃ��s��C��
        if (now_stage_number==1&&P_Money >= stage_1_LevelUP && P_LevelUP == false)
        {
            P_LevelUP = true;
            DustFULL = false;
        }

        if (now_stage_number==2&& P_Money >= stage_2_LevelUP && P_LevelUP == false)
        {
            P_LevelUP = true;
            DustFULL = false;
        }
        //-----------------------------------------------------------------


        //   //�v���C���[�ϐ����Z�b�g----------------------------------------
        if (P_HP <= 0)//�K����3�񓖂���ƃQ�[���[�I�[�o�[
        {
            Player_reset();
            SceneManager.LoadScene(sceneName);
            //FadeManager.Instance.LoadScene(sceneName, 0.7f);
        }
        if (Input.GetKeyDown(KeyCode.R))//���X�^�[�g����
        {
            //�v���C���[�ϐ����Z�b�g
            Player_reset();
            SceneManager.LoadScene(sceneName2);
            //FadeManager.Instance.LoadScene(sceneName2, 0.7f);
        }

        if(now_stage_number==1)//�X�e�[�W1�Ȃ�
        {
            if (DustBOX >= stage_1_MAXPoint)//20�ȏ�ɂȂ�Ƒ��N���A��ʂɂȂ�
            {
                Game_Clear_Score1 = DustBOX;
                Debug.Log("�X�e�[�W1   "+Game_Clear_Score1);
                //�v���C���[�ϐ����Z�b�g
                Player_reset();
                SceneManager.LoadScene(sceneName3);
                //FadeManager.Instance.LoadScene(sceneName3, 0.7f);
            }
        }

        if (now_stage_number == 2)//�X�e�[�W2�Ȃ�
        {
            if (DustBOX >= stage_2_MAXPoint)//38�ȏ�ɂȂ�Ƒ��N���A��ʂɂȂ�
            {
                Game_Clear_Score2 = DustBOX;
                Debug.Log("�X�e�[�W2   " + Game_Clear_Score2);
                //�v���C���[�ϐ����Z�b�g
                Player_reset();
                SceneManager.LoadScene(sceneName3);
                //FadeManager.Instance.LoadScene(sceneName3, 0.7f);

                Rank += Game_Clear_Score1 + Game_Clear_Score2;

                if(Rank>=45&&50>Rank)
                {
                    Debug.Log("E");
                }
                if (Rank >= 50&&55>Rank)
                {
                    Debug.Log("B");
                }
                if (Rank >= 55&&58>Rank)
                {
                    Debug.Log("A");
                }
                if (Rank >= 58)
                {
                    Debug.Log("S");
                }
            }
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

    //�֐�------------------------------------------------------------
    private void MovePlayer()//�ړ�
    {
        rb.AddForce(movement.normalized * moveSpeed);//�ړ�

    }

    public static void Player_reset() //�v���C���[�ϐ����Z�b�g
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
        DOTween.Clear(true);
    }

    IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(0.5f);//0.5�b�_�ł���
                                               // �ʏ��Ԃɖ߂�
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }
    //-----------------------------------------------------------------

    //�����蔻��-----------------------------------------------��
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
              strength: 0.4f  // �V�F�C�N�̋���
                              );
        }

        if (collision.gameObject.tag == "dust" && DustFULL == true)//�e�ʂ����ς��ŃS�~�ɓ�����ƃr�[�v������
        {
            audioSource.PlayOneShot(sound6);
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
            P_Effect.Effect_flg = true;//�v���C���[�̓d��effect�t�^
            audioSource.PlayOneShot(sound5);
            P_HP--;
            isDamage = true;
            transform.DOShakeScale(
            duration: 0.3f,   // ���o����
            strength: 0.5f  // �V�F�C�N�̋���
              );
        }

        //�����q�b�g��------------------------------------------------------------
        if (collision.gameObject.tag == "10")//�P�O�~�ɓ������...
        {
            P_Money += 10;
            audioSource.PlayOneShot(sound2);
            transform.DOShakeScale(
    duration: 0.3f,   // ���o����
    strength: 0.3f  // �V�F�C�N�̋���
);
        }
        if (collision.gameObject.tag == "100")//�P�O�O�~�ɓ������...
        {
            P_Money += 100;
            audioSource.PlayOneShot(sound2);
            transform.DOShakeScale(
   duration: 0.3f,   // ���o����
   strength: 0.3f  // �V�F�C�N�̋���
   );
        }
        if (collision.gameObject.tag == "500")//�T�O�O�~�ɓ������...
        {
            P_Money += 500;
            audioSource.PlayOneShot(sound2);
            transform.DOShakeScale(
   duration: 0.3f,   // ���o����
   strength: 0.3f  // �V�F�C�N�̋���
   );
        }
        //------------------------------------------------------------------------

    }
}
