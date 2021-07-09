using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*
 * -Name : Mart_RandomItem.cs
 * -Content : Random selection of items, so that they are not duplicated
 * 
 * -Variable 
 * mg_RandomItem
 * mg_GameDirector
 * mspa_SpriteImage : Sprite Image of Items
 * mn_RandomValue : Random value storage variables for item selection
 * mn_leftTime : Number of items remaining
 * mb_ItemFlag : 
 * 
 * 
 * 
 * -Function
 * n_Answer() : return the 'mn_RandomValue'
 * 
 * 
 */



public class Mart_RandomItem : MonoBehaviour{

    GameObject mg_RandomItem;
    GameObject mg_GameDirector;

    public Sprite[] mspa_SpriteImage = new Sprite[6];

    int mn_RandomValue;
    int mn_leftTime;

    bool mb_ItemFlag;



    void Start(){
        this.mg_GameDirector = GameObject.Find("GameDirector");
        this.mg_RandomItem = GameObject.Find("Mart_RandomItem");

        mn_RandomValue = mg_GameDirector.GetComponent<Mart_ControlUI>().n_MartRandomItemValue();
        this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue];

        mb_ItemFlag = false;
    }

    void Update(){
        mb_ItemFlag = mg_GameDirector.GetComponent<Mart_ControlUI>().b_checkFlag();
        if (mb_ItemFlag == true){
            mn_leftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();
            if(mn_leftTime != 0){
                mn_RandomValue = mg_GameDirector.GetComponent<Mart_ControlUI>().n_MartRandomItemValue();
                this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue];


                mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagFalse();
            }
            else if(mn_leftTime == 0){  // If you clear the game
                SceneManager.LoadScene("end_scene");
            } 
        }
    }

    public int n_Answer(){
        return mn_RandomValue;
    }
}
