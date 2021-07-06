using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }

    //private void OnMouseDrag()
    //{
    //    Vector2 v_mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    Vector2 v_worldObjPos = Camera.main.ScreenToWorldPoint(v_mousePosition);

    //    this.transform.position = v_worldObjPos;
    //}

}
