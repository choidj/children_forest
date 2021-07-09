using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape_Matching_Shape : MonoBehaviour{
    public bool mb_classifyWhetherAns = false;
    public Sprite[] msl_changeAnsImg = new Sprite[4];
    public Sprite NextSprite;

    void OnTriggerEnter2D(Collider2D cCollideObject){
        if (cCollideObject.name[cCollideObject.name.Length - 1] == this.name[this.name.Length - 1]){
            if (mb_classifyWhetherAns)
                gameObject.GetComponent<SpriteRenderer>().sprite = NextSprite;
            else
                Destroy(this.gameObject);
        }
    }
}



