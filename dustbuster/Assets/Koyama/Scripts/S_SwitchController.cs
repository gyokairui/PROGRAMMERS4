using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SwitchController : MonoBehaviour
{
    public string sceneName;//シーン名inspectorで指定

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}