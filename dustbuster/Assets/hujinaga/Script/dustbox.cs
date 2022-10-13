using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dustbox : MonoBehaviour
{
    public Slider slider;
    private Rigidbody2D rb;

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
        if (collision.gameObject.tag == "dustbox")//ƒSƒ~‚É“–‚½‚é‚Æ...
        {
            //Score++;
            //Debug.Log(Score);
            slider.value++;
        }

    }
}
