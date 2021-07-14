using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DragJack : MonoBehaviour{
    void OnTriggerEnter2D(Collider2D cCollideObject){
        if(cCollideObject.tag == "Jack"){   
            OnMouseDrag();
        }
        else if(cCollideObject.tag == "Door"){
            SceneManager.LoadScene("Jack_Epi14");
        }
    }

    void OnMouseDrag(){
                Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
                this.transform.position = v2worldObjPos;
    }
}