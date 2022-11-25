using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SwitchController : MonoBehaviour
{
    public string sceneName;//ÉVÅ[ÉìñºinspectorÇ≈éwíË

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}