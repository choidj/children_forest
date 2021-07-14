using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jack_drag : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }
}