using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;�@�@�@//�{�^�����g�p����̂�UI
using UnityEngine.SceneManagement;//SceneManager���g�p����SceneManagement��ǉ�

public class SceneController : MonoBehaviour
{
    public string sceneName;

    // �{�^�����N���b�N�����Scene�wB�x�Ɉړ�
    public void ButtonClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}