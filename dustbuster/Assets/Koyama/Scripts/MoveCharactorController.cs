using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCharactorController : MonoBehaviour
{
    private float speed = 0.01f;

    public string sceneName;//�V�[����inspector�Ŏw��

    void Start()
    {

    }

    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey("left"))
        {
            position.x -= speed;
        }
        else if (Input.GetKey("right"))
        {
            position.x += speed;
        }
        else if (Input.GetKey("up"))
        {
            position.y += speed;
        }
        else if (Input.GetKey("down"))
        {
            position.y -= speed;
        }

        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("c");
            ////PlayerPrefs��SCORE��3�Ƃ����l������
            //PlayerPrefs.SetInt("SCORE", 3);
            ////PlayerPrefs���Z�[�u����         
            //PlayerPrefs.Save(); 
        }
    }
}