using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowUI : MonoBehaviour
{
    //矢印のアニメーション---------
    public Animation arrow_anim1; 
    public Animation arrow_anim2;
    public Animation arrow_anim3;
    public Animation arrow_anim4;
    public Animation arrow_anim5;
    public Animation arrow_anim6;
    public Animation arrow_anim7;
    public Animation arrow_anim8;
    //-----------------------------

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
        if(collision.gameObject.tag == "arrow")
        {

        }
    }
}
