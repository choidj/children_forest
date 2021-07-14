using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Drag_Jack : MonoBehaviour
{   
    void OnTriggerEnter2D(Collider2D cCollideObject){
        OnMouseDrag();
        
        if(cCollideObject.tag == "Closet"){
            SceneManager.LoadScene("Jack_Epi9");
        }
    }
    void OnMouseDrag(){
                Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
                this.transform.position = v2worldObjPos;
    }
}
