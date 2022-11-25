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
            //PlayerPrefsのSCOREに2という値を入れる
            PlayerPrefs.SetInt("SCORE", 2);
            //PlayerPrefsをセーブする         
            PlayerPrefs.Save();

        }
    }
}