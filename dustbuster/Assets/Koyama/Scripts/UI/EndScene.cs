using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{

    void Start()
    {
        _startTime = Time.realtimeSinceStartup;
    }
    public GameObject endScene;
    private float _startTime;

    void Update()
    {
        if (Time.realtimeSinceStartup - _startTime >= 7.5f)
            endScene.SetActive(true);
    }

}