using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeManager : MonoBehaviour
{
    //�J�E���g�_�E��
    public float countdown = 5.0f;

    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;
    public string sceneName1;//�V�[����inspector�Ŏw��
    public string sceneName2;//�V�[����inspector�Ŏw��
    // Update is called once per frame
    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        countdown -= Time.deltaTime;

        //���Ԃ�\������
        timeText.text = countdown.ToString("f1") + "�b";

        //countdown��0�ȉ��ɂȂ����Ƃ�
        if (countdown <= 0)
        {
            timeText.text = "�^�C���A�b�v";
            if(Player.Score>=20)//�S�~�����ȏ゠��ƃN���A
            {
                Player.P_HP = 3;
                Player.DustBOX = 0;
                Player.Score = 0;
                Player.P_Money = 0;
                Player.GameOver_flg = true;
                Player.DustFULL = false;
                Player.GameOver_flg = false;
                SceneManager.LoadScene(sceneName1);
            }

            if (Player.Score < 20)//�S�~�����ȏ㖳���ƃQ�[���I�[�o�[
            {
                Player.P_HP = 3;
                Player.DustBOX = 0;
                Player.Score = 0;
                Player.P_Money = 0;
                Player.GameOver_flg = true;
                Player.DustFULL = false;
                Player.GameOver_flg = false;
                SceneManager.LoadScene(sceneName2);
            }
        }

    }
}