/*
 * - Name : DragDestroy.cs
 * - Writer : 최대준
 * - Content : 잭과콩나무 에피소드1 - 
 * -기록-
 * 2021-07-21 : 작성
 * Destroy(GameObject.Find("speechBubble")): 말 풍선을 없애는 함수 이다.
   Destroy(GameObject.Find("Canvas")) : 대사(canvas)를 없애는 함수 이다.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        Destroy(GameObject.Find("speechBubble"));
        Destroy(GameObject.Find("Canvas"));
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }
}
