using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // �ǉ����܂��傤

public class N_Clear : MonoBehaviour
{
    public GameObject score_object = null; // Text�I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();
        // �e�L�X�g�̕\�������ւ���
       
        if (Player.Rank >= 45 && 50 > Player.Rank)
        {
            Debug.Log("E");
            score_text.text = "E";
        }
        if (Player.Rank >= 50 && 55 > Player.Rank)
        {
            Debug.Log("B");
            score_text.text = "B";
        }
        if (Player.Rank >= 55 && 58 > Player.Rank)
        {
            Debug.Log("A");
            score_text.text = "A";
        }
        if (Player.Rank >= 58)
        {
            Debug.Log("S");
            score_text.text = "S";
        }
    }
}
