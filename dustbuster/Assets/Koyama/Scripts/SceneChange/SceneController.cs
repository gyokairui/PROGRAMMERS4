using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static int Number = DestroyScript.stage_N;

    public string sceneName;//シーン名inspectorで指定

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
        //PlayerPrefsのSCOREに3という値を入れる
        //PlayerPrefs.SetInt("SCORE", 4);
        //PlayerPrefsをセーブする         
        //PlayerPrefs.Save();
        Number = 2;

        //Debug.Log("b");
    }
}