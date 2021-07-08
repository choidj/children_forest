using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matching : MonoBehaviour
{
    public bool mb_classifyWhetherAns = false;
    public Sprite[] msl_changeAnsImg = new Sprite[9];

    void OnTriggerEnter2D(Collider2D cCollideObject)
    {
        if (cCollideObject.name[cCollideObject.name.Length - 1] == this.name[this.name.Length - 1])
        {
            if (mb_classifyWhetherAns)
            {
                Color tempColor = gameObject.GetComponent<SpriteRenderer>().color;
                tempColor.a = 1f;
                gameObject.GetComponent<SpriteRenderer>().color = tempColor;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

    }
}