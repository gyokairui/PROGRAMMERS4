using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustrange : MonoBehaviour
{
    public bool dustflag=false;

    public GameObject objParent;
   

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
            //dustflag = true;
            GameObject objParent = transform.parent.gameObject;
            TargetMoveScript scParent = objParent.GetComponent<TargetMoveScript>();
            scParent.flg = true;
        }

    }
   
}
