using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeManager : MonoBehaviour
{
    //�J�E���g�_�E��
    public float countdown = 60.0f;

    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;

    //�V�[���֌W-----------------------------------------------
    public string SceneName1;//�Q�[���I�[�o�[
    public string SceneName2;//�Q�[���N���A�[
    //----------------------------------------------------

    void start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        countdown -= Time.deltaTime;

        //���Ԃ�\������
        timeText.text = countdown.ToString("f1") + "�b";

        //countdown��0�ȉ��ɂȂ����Ƃ�
        //�X�e�[�^�X������
        if (countdown <= 0)
        {
            //timeText.text = "�^�C���A�b�v";

            if (Player.now_stage_number==1)
            {
                //�X�e�[�W�P�̏ꍇ
                if (Player.DustBOX >= Player.stage_1_clearPoint)//�S�~�����ȏ゠��ƃN���A
                {
                    Player.Player_reset();//�v���C���[�ϐ����Z�b�g
                    SceneManager.LoadScene(SceneName2);
                }
                //�S�~�����ȏ㖳���ƃQ�[���I�[�o�[
                else
                {
                    Player.Player_reset();//�v���C���[�ϐ����Z�b�g
                    SceneManager.LoadScene(SceneName1);
                }
            }

            if (Player.now_stage_number == 2)
            {
                //�X�e�[�W�P�̏ꍇ
                if (Player.DustBOX >= Player.stage_2_clearPoint)//�S�~�����ȏ゠��ƃN���A
                {
                    Player.Player_reset();//�v���C���[�ϐ����Z�b�g
                    SceneManager.LoadScene(SceneName2);
                }
                //�S�~�����ȏ㖳���ƃQ�[���I�[�o�[
                else
                {
                    Player.Player_reset();//�v���C���[�ϐ����Z�b�g
                    SceneManager.LoadScene(SceneName1);
                }
            }
        }

    }
}