using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text textUI;

    void Start()
    {
        //�R���[�`���̎��s
        StartCoroutine("Hoge");
    }

    private IEnumerator Hoge()
    {
        //���b�҂�
        yield return new WaitForSeconds(2.5f);

        //���b�҂�����̏���
        textUI.text = "";
    }
}
