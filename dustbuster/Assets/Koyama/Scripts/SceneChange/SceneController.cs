using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static int Number = DestroyScript.stage_N;

    public string sceneName;//�V�[����inspector�Ŏw��

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
        //PlayerPrefs��SCORE��3�Ƃ����l������
        //PlayerPrefs.SetInt("SCORE", 4);
        //PlayerPrefs���Z�[�u����         
        //PlayerPrefs.Save();
        Number = 2;

        //Debug.Log("b");
    }
}