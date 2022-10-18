using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryController : MonoBehaviour
{
    public string sceneName;//シーン名inspectorで指定

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Debug.Log("Inputed");
            SceneManager.LoadScene(sceneName);
        }
    }
}