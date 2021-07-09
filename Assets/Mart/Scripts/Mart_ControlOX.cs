using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * -Name : Mart_ControlOX.cs
 * -Content : Control the OX Image
 * 
 * -Variable 
 * mg_O
 * mg_X
 * 
 * 
 * 
 * 
 * -Function
 * 
 * 
 */



public class Mart_ControlOX : MonoBehaviour{
    public GameObject mg_O;
    public GameObject mg_X;


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void v_ShowO(){

        GameObject show = Instantiate(mg_O) as GameObject;
        show.transform.position = new Vector3(0, 0, 0);
        Debug.Log("mg_O이미지 생성");

        Destroy(show, 1);
        Debug.Log("mg_O이미지 삭제");
    }

    public void v_ShowX(){
        GameObject show = Instantiate(mg_X) as GameObject;
        show.transform.position = new Vector3(0, 0, 0);
        Debug.Log("mg_X이미지 생성");

        Destroy(show,1);
        Debug.Log("mg_X이미지 삭제");
    }
}
