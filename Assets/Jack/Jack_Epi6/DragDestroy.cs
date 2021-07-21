using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDestroy : MonoBehaviour
{    private void OnMouseDrag()
    {
        Destroy(GameObject.Find("speechBubble"));
        Destroy(GameObject.Find("Canvas"));
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }
}
