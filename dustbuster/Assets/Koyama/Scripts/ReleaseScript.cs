using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseScript : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //PlayerPrefs��SCORE��2�Ƃ����l������
            PlayerPrefs.SetInt("SCORE", 2);
            //PlayerPrefs���Z�[�u����         
            PlayerPrefs.Save();

        }
    }
}