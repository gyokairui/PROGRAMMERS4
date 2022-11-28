using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustrange : MonoBehaviour
{
    public bool dustflag=false;
    public static float sizeCount;
    public GameObject objParent;

    [SerializeField] private CapsuleCollider2D capsuleCollider2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      if(Player.P_Money>=Player.stage_1_LevelUP)
        {
            //プレイヤーがレベルアップするとゴミの判定距離が伸びる
            capsuleCollider2.size = new Vector2(4, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//プレイヤーに当たると...
        {
            //プレイヤーに向かって進む
            GameObject objParent = transform.parent.gameObject;
            TargetMoveScript scParent = objParent.GetComponent<TargetMoveScript>();
            scParent.flg = true;
        }

    }
   
}
