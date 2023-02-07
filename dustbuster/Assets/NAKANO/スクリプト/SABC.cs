using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SABC : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        // 色を指定
        //text.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();
        if (Player.Rank >= 45 && 50 > Player.Rank)
        {
            score_text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            score_text.text = "E";
            Debug.Log("E");
            Player.Rank = 0;
        }
        if (Player.Rank >= 50 && 55 > Player.Rank)
        {
            score_text.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);

            score_text.text = "B";
            Debug.Log("B");
            Player.Rank = 0;
        }
        if (Player.Rank >= 55 && 58 > Player.Rank)
        {
            score_text.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);

            score_text.text = "A";
            Debug.Log("A");
            Player.Rank = 0;
        }
        if (Player.Rank >= 58)
        {
            score_text.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);

            score_text.text = "S";
            Debug.Log("S");
            Player.Rank = 0;
        }
    }
}
