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

        if(this.tag == "Mart_Item1")
        {
            this.transform.position = new Vector3(6.1f, 2.75f, 0);
        }
        if (this.tag == "Mart_Item2")
        {
            this.transform.position = new Vector3(9.5f, 2.75f, 0);
        }
        if (this.tag == "Mart_Item3")
        {
            this.transform.position = new Vector3(6.1f, 0, 0);
        }
        if (this.tag == "Mart_Item4")
        {
            this.transform.position = new Vector3(9.5f, 0f, 0);
        }
        if (this.tag == "Mart_Item5")
        {
            this.transform.position = new Vector3(6.1f, -3f, 0);
        }
        if (this.tag == "Mart_Item6")
        {
            this.transform.position = new Vector3(9.5f, -3f, 0);
        }

    }
}
