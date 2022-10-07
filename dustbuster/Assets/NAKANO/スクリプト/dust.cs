using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dust : MonoBehaviour
{
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
        if (collision.gameObject.tag == "Player")//ÉvÉåÉCÉÑÅ[Ç…ìñÇΩÇÈÇ∆...
        {
            //Debug.Log("Åö");
            Destroy(this.gameObject);
            //Player.Score++;
            //Debug.Log(Player.Score);
        }

    }
}
