using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dust : MonoBehaviour
{
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&Player.DustFULL==false)//プレイヤーに当たると...
        {
            //消える
            Destroy(this.gameObject);
        }
    }
}
