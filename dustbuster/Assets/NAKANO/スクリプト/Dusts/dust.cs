using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dust : MonoBehaviour
{
   // public static bool P_dustflag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&Player.DustFULL==false)//ÉvÉåÉCÉÑÅ[Ç…ìñÇΩÇÈÇ∆...
        {
            //Debug.Log("Åö");
            Destroy(this.gameObject);
            //Player.Score++;
            //Debug.Log(Player.Score);
            //P_dustflag = true;
        }
    }
}
