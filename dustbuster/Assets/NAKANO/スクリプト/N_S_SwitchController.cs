using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class N_S_SwitchController : MonoBehaviour
{
    public string N_sceneName;//ÉVÅ[ÉìñºinspectorÇ≈éwíË

    public void SwitchScene()
    {
        SceneManager.LoadScene(N_sceneName);
    }
}