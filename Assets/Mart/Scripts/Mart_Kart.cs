using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * -Name : Mart_RandomItem.cs
 * -Content : Random selection of items, so that they are not duplicated
 * 
 * -Variable 
 * mg_GameDirector
 * mg_ShowOX
 * mg_MartRandomItem
 * mn_answer   
 * mn_LeftTime
 * 
 * 
 * 
 * 
 * -Function
 * OnTriggerEnter2D(Collider2D cCollidObj) : When an object conflicts
 * 
 * 
 */




public class Mart_Kart : MonoBehaviour{
    GameObject mg_GameDirector;
    GameObject mg_ShowOX;
    GameObject mg_MartRandomItem;

    int mn_answer;
    int mn_LeftTime;

    void Start(){
        this.mg_GameDirector = GameObject.Find("GameDirector");
        this.mg_ShowOX = GameObject.Find("ShowOX");
        this.mg_MartRandomItem = GameObject.Find("Mart_RandomItem");

    }

    void Update(){
        mn_answer = mg_MartRandomItem.GetComponent<Mart_RandomItem>().n_Answer();
    }

    void OnTriggerEnter2D(Collider2D cCollidObj){
        if (cCollidObj.tag == "Mart_Item1" && mn_answer == 0){
            Debug.Log("Mart_Item1 삭제");

            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(0);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if(cCollidObj.tag == "Mart_Item1" && mn_answer != 0){
            Debug.Log("오답");

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();

        }
        if (cCollidObj.tag == "Mart_Item2" && mn_answer == 1){
            Debug.Log("Mart_Item2 삭제");

            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(1);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item2" && mn_answer != 1){
            Debug.Log("오답");

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();

        }
        if (cCollidObj.tag == "Mart_Item3" && mn_answer == 2){
            Debug.Log("Mart_Item3 삭제");

            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(2);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item3" && mn_answer != 2){
            Debug.Log("오답");

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();

        }
        if (cCollidObj.tag == "Mart_Item4" && mn_answer == 3){
            Debug.Log("Mart_Item4 삭제");

            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(3);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item4" && mn_answer != 3){
            Debug.Log("오답");

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();

        }
        if (cCollidObj.tag == "Mart_Item5" && mn_answer == 4){
            Debug.Log("Mart_Item5 삭제");

            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(4);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item5" && mn_answer != 4){
            Debug.Log("오답");

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();

        }
        if (cCollidObj.tag == "Mart_Item6" && mn_answer == 5){
            Debug.Log("Mart_Item6 삭제");

            mg_GameDirector.GetComponent<Mart_ControlUI>().v_MartCheckRandomItemArr(5);
            mn_LeftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            Destroy(cCollidObj.gameObject);
            mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagTrue();

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowO();
        }
        if (cCollidObj.tag == "Mart_Item6" && mn_answer != 5){
            Debug.Log("오답");

            mg_ShowOX.GetComponent<Mart_ControlOX>().v_ShowX();
        }
    }
}
