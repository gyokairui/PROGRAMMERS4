using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dustbox : MonoBehaviour
{
    private Rigidbody2D rb;
    public static int trash;
    public static dustbox d_box;
    public Slider Slider_G; //ゴミ箱のゲージタンク

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
        if (collision.gameObject.tag == "Player")//ゴミに当たると...
        {
            
        }

    }
}
