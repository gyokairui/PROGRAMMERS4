using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン遷移させる場合に必要

public class E_1 : MonoBehaviour
{
    public float speed;
    void Start()
    {
        DontDestroyOnLoad(gameObject); //シーンを切り替えても削除しない
        speed = 5;
    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float dz = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector3(
            transform.position.x + dx, 0.5f, transform.position.z + dz
            );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}