using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Effect_flg=false;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Effect_flg==true)//ƒKƒ€‚É“–‚½‚é‚Æ...
        {
            anim.SetTrigger("biribiri");
            Effect_flg = false;
        }
    }

   
}