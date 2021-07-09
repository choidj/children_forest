using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



/*
 * -Name : Mart_MouseDrag.cs
 * -Content : Processing based on Mouse Events
 * 
 * 
 * -Variable 
 * mv2_mouseDragPosition
 * mv2_worldObjectPosition
 * 
 * 
 * 
 * 
 * -Function
 * OnMouseDown() : touch the object
 * OnMouseDrag() : drag
 * OnMouseUp() : When you take your hands off the mouse.
 * 
 * 
 * 
 */







public class Mart_MouseDrag : MonoBehaviour
{
    void Start(){

    }

    void Update(){

    }

    private void OnMouseDown(){
        Debug.Log("오브젝트 터치");
    }

    private void OnMouseDrag(){
        Vector2 mv2_mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mv2_worldObjectPosition = Camera.main.ScreenToWorldPoint(mv2_mouseDragPosition);
        this.transform.position = mv2_worldObjectPosition;
        Debug.Log("오브젝트 드래그");


    }

    private void OnMouseUp(){
        Debug.Log("오브젝트에서 손 뗌");

        if(this.tag == "Mart_Item1"){
            this.transform.position = new Vector3(6.1f, 2.75f, 0);
        }
        if (this.tag == "Mart_Item2"){
            this.transform.position = new Vector3(9.5f, 2.75f, 0);
        }
        if (this.tag == "Mart_Item3"){
            this.transform.position = new Vector3(6.1f, 0, 0);
        }
        if (this.tag == "Mart_Item4"){
            this.transform.position = new Vector3(9.5f, 0f, 0);
        }
        if (this.tag == "Mart_Item5"){
            this.transform.position = new Vector3(6.1f, -3f, 0);
        }
        if (this.tag == "Mart_Item6"){
            this.transform.position = new Vector3(9.5f, -3f, 0);
        }
    }
}
