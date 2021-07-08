using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
    private void OnMouseDrag() {
        Vector2 v_mousePosition = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v_worldObjPos = Camera.main.ScreenToWorldPoint(v_mousePosition);
        this.transform.position = v_worldObjPos;
    }
}