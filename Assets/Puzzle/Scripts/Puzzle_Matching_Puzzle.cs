using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_Matching_Puzzle : MonoBehaviour{
    public bool mb_classifyWhetherAns = false;
    //public Sprite[] msa_changeAnsImg = new Sprite[9];

    private void Start(){
        if(!mb_classifyWhetherAns){
            transform.position = new Vector3(Random.Range(18, 26), Random.Range(3, 11), 0);
        }
    }

    void OnTriggerEnter2D(Collider2D cCollideObject){
        if (cCollideObject.name[cCollideObject.name.Length - 1] == this.name[this.name.Length - 1]){
            if (mb_classifyWhetherAns){
                Color tempColor = gameObject.GetComponent<SpriteRenderer>().color;
                tempColor.a = 1f;
                gameObject.GetComponent<SpriteRenderer>().color = tempColor;
            }
            else{
                Destroy(this.gameObject);
            }
        }
    }
}