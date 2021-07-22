/*
 * - Name : DragDestroy.cs
 * - Writer : 최대준
 * - Content : 잭과콩나무 에피소드1 - 
 *          -기록-
 *          2021-07-21 : 작성
 * - DragDestroy Member variable
 * null
 * - DragDestroy Member function
 * OnMouseDrag() : 드래그 시에 잭에게 띄워놓았던 말풍선을 없애는 함수이다.
 * SceneManager.LoadScene("") : 다음 Scene으로 이동 하는 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 잭의 말풍선이 드래그하여 위치가 변했을 때에도 띄워져 있는 것이 부자연스러워 추가한 스크립트이다. 잭이 드래그되면 말풍선이 사라지도록 지정하였다.
public class DragDestroy : MonoBehaviour {
    // 드래그시에 말풍선을 사라지도록 하였다.
    private void OnMouseDrag()
    {
        Destroy(GameObject.Find("speechBubble"));
        Destroy(GameObject.Find("ScriptCanvas"));
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }
}
