using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeElapsedController : MonoBehaviour
{
    public Text textUI;

    void Start()
    {
        //�R���[�`���̎��s
        StartCoroutine("Hoge");
    }

    private IEnumerator Hoge()
    {

        textUI.text = "��������";

        //���b�҂�
        yield return new WaitForSeconds(2.5f);

        //���b�҂�����̏���
        textUI.text = "�uWASD�v�F�ړ�";
        //textUI.text = "�uEnter�v:";

        //���b�҂�
        yield return new WaitForSeconds(2.5f);

        //���b�҂�����̏���
        textUI.text = "�uR�v�@ :���X�^�[�g";

        //���b�҂�
        yield return new WaitForSeconds(2.5f);

        //���b�҂�����Ƀe�L�X�g������
        //�e�L�X�g������@�킩���
        textUI.text = "";

    }
}