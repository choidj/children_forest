using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDrag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("오브젝트 터치");
    }

    private void OnMouseDrag()
    {
        Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);
        this.transform.position = worldObjectPosition;
        Debug.Log("오브젝트 드래그");
    }

    private void OnMouseUp()
    {
        Debug.Log("오브젝트에서 손 뗌");
    }
}
