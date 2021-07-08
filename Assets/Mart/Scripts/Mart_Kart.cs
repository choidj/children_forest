using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_Kart : MonoBehaviour
{
    GameObject GameDirector;

    int LeftTime;

    // Start is called before the first frame update
    void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    void OnTriggerEnter2D(Collider2D collidObj)
    {
        if (collidObj.tag == "Mart_Item1")
        {
            Debug.Log("Mart_Item1 昏力");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(0);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
            
            
            //GameDirector.GetComponent<Mart_ControlUI>().testqq();
        }
        if (collidObj.tag == "Mart_Item2")
        {
            Debug.Log("Mart_Item2 昏力");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(1);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
        }
        if (collidObj.tag == "Mart_Item3")
        {
            Debug.Log("Mart_Item3 昏力");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(2);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
        }
        if (collidObj.tag == "Mart_Item4")
        {
            Debug.Log("Mart_Item4 昏力");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(3);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
        }
        if (collidObj.tag == "Mart_Item5")
        {
            Debug.Log("Mart_Item5 昏力");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(4);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
        }
        if (collidObj.tag == "Mart_Item6")
        {
            Debug.Log("Mart_Item6 昏力");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(5);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
        }


        Destroy(collidObj.gameObject);
        GameDirector.GetComponent<Mart_ControlUI>().ChangeFlagTrue();
    }
}
