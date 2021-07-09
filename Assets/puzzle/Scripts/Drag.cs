using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour{
    private void OnMouseDrag(){
        Vector2 v2mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 v2worldObjPos = Camera.main.ScreenToWorldPoint(v2mousePosition);
        this.transform.position = v2worldObjPos;
    }
}