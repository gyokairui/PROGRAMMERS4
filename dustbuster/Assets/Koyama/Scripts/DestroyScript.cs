using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public int stage_n; // �X�R�A�ϐ�
    public GameObject b;

    // Start is called before the first frame update
    void Start()
    {
        stage_n = PlayerPrefs.GetInt("SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //stage_num���Q�ȏ�̂Ƃ��A�X�e�[�W�Q���������B
        if (stage_n >= 2)
        {
            Destroy(gameObject);
        }
    }
}
