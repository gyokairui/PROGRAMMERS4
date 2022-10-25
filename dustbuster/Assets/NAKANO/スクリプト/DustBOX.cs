using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DustBOX : MonoBehaviour
{
    bool BOX_Time = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&BOX_Time==true)//プレイヤーに当たると...
        {
            transform.DOShakeScale(
 duration: 0.5f,   // 演出時間
 strength: 1f  // シェイクの強さ
 );
            BOX_Time = false;
            Invoke("BOX", 1);
        }
    }

    void BOX()
    {
        BOX_Time = true;
    }
}
