using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public static int stage_N = 1; // �X�R�A�ϐ�
    public GameObject b;

    int a = SceneController.Number;

    // Start is called before the first frame update
    void Start()
    {
        //stage_n = PlayerPrefs.GetInt("SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //stage_num��3�ȏ�̂Ƃ��A�X�e�[�W�Q���������B
        if (a >= 2)
        {
            Destroy(b);
            //Debug.Log("a");
        }
    }
}
