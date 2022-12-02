using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Effect_flg=false;

    bool LevelUP_flg = false;
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


        if (Player.now_stage_number == 1 && Player.P_Money >= Player.stage_1_LevelUP&&LevelUP_flg==false)
        {
            anim.SetTrigger("UP");
            LevelUP_flg = true;
        }
        //ƒXƒe[ƒW‚Q‚Ìê‡
        if (Player.now_stage_number == 2 && Player.P_Money >= Player.stage_2_LevelUP&&LevelUP_flg==false)
        {
            anim.SetTrigger("UP");
            LevelUP_flg = true;
        }
    }

   
}