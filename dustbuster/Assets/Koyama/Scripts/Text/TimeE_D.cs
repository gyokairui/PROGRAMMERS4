using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeE_D : MonoBehaviour
{
    public Text textUI;

    void Start()
    {
        //�R���[�`���̎��s
        StartCoroutine("Hoge");
    }

    private IEnumerator Hoge()
    {

        textUI.text = "";

        //���b�҂�
        yield return new WaitForSeconds(7.5f);

        //���b�҂�����̏���
        //textUI.text = "�uW�v�F��";
        //textUI.text = "�uS�v�F��";
        textUI.text = "[D]�F�E";
        //textUI.text = "�uA�v�F��";

    }
}
