using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAx : MonoBehaviour
{   
    // private bool mf_checkGetAxe = false;
    public GameObject Jack;
    public GameObject Ax;
    public GameObject Click;
    public ScriptControl sc;
    private bool mf_checkGetAxe = false;
    SpriteRenderer rend;
    void Start() {
        Click = GameObject.Find("Click");
        sc = ScriptControl.GetInstance();
    }
    public void OnMouseDrag(){
        Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
        Destroy(Click);
        this.transform.position = v2worldObjPos;
    }
    void OnTriggerEnter2D(Collider2D cCollideObject){
        if (cCollideObject.tag == "Jack" && !mf_checkGetAxe){
            // Debug.Log(transfrom.gameObject.name);
            rend =  Jack.GetComponent<SpriteRenderer>();
            rend.flipX = false;
            transform.position = Jack.transform.position;
            sc.setNextScript();
            mf_checkGetAxe = true;
        }
    }
}
