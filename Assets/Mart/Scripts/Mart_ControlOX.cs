using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_ControlOX : MonoBehaviour
{
    public GameObject O;
    public GameObject X;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowO()
    {

        GameObject show = Instantiate(O) as GameObject;
        show.transform.position = new Vector3(0, 0, 0);
        Debug.Log("O�̹��� ����");

        Destroy(show, 1);
        Debug.Log("O�̹��� ����");
    }

    public void ShowX()
    {
        GameObject show = Instantiate(X) as GameObject;
        show.transform.position = new Vector3(0, 0, 0);
        Debug.Log("X�̹��� ����");

        Destroy(show,1);
        Debug.Log("X�̹��� ����");
    }
}
