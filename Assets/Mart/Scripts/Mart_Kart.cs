using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_Kart : MonoBehaviour
{
    GameObject GameDirector;
    GameObject ShowOX;
    GameObject Mart_RandomItem;

    int answer;
    int LeftTime;

    // Start is called before the first frame update
    void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector");
        this.ShowOX = GameObject.Find("ShowOX");
        this.Mart_RandomItem = GameObject.Find("Mart_RandomItem");

    }

    // Update is called once per frame
    void Update()
    {
        answer = Mart_RandomItem.GetComponent<Mart_RandomItem>().Answer();



    }

    void OnTriggerEnter2D(Collider2D collidObj)
    {
        if (collidObj.tag == "Mart_Item1" && answer == 0)
        {
            Debug.Log("Mart_Item1 ����");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(0);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
            Destroy(collidObj.gameObject);
            GameDirector.GetComponent<Mart_ControlUI>().ChangeFlagTrue();

            ShowOX.GetComponent<Mart_ControlOX>().ShowO();

            //GameDirector.GetComponent<Mart_ControlUI>().testqq();
        }
        if(collidObj.tag == "Mart_Item1" && answer != 0)
        {
            Debug.Log("����");
         
            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }
        if (collidObj.tag == "Mart_Item2" && answer == 1)
        {
            Debug.Log("Mart_Item2 ����");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(1);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
            Destroy(collidObj.gameObject);
            GameDirector.GetComponent<Mart_ControlUI>().ChangeFlagTrue();

            ShowOX.GetComponent<Mart_ControlOX>().ShowO();
        }
        if (collidObj.tag == "Mart_Item2" && answer != 1)
        {
            Debug.Log("����");

            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }
        if (collidObj.tag == "Mart_Item3" && answer == 2)
        {
            Debug.Log("Mart_Item3 ����");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(2);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
            Destroy(collidObj.gameObject);
            GameDirector.GetComponent<Mart_ControlUI>().ChangeFlagTrue();

            ShowOX.GetComponent<Mart_ControlOX>().ShowO();
        }
        if (collidObj.tag == "Mart_Item3" && answer != 2)
        {
            Debug.Log("����");

            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }
        if (collidObj.tag == "Mart_Item4" && answer == 3)
        {
            Debug.Log("Mart_Item4 ����");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(3);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
            Destroy(collidObj.gameObject);
            GameDirector.GetComponent<Mart_ControlUI>().ChangeFlagTrue();

            ShowOX.GetComponent<Mart_ControlOX>().ShowO();
        }
        if (collidObj.tag == "Mart_Item4" && answer != 3)
        {
            Debug.Log("����");

            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }
        if (collidObj.tag == "Mart_Item5" && answer == 4)
        {
            Debug.Log("Mart_Item5 ����");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(4);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
            Destroy(collidObj.gameObject);
            GameDirector.GetComponent<Mart_ControlUI>().ChangeFlagTrue();

            ShowOX.GetComponent<Mart_ControlOX>().ShowO();
        }
        if (collidObj.tag == "Mart_Item5" && answer != 4)
        {
            Debug.Log("����");

            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }
        if (collidObj.tag == "Mart_Item6" && answer == 5)
        {
            Debug.Log("Mart_Item6 ����");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(5);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
            Destroy(collidObj.gameObject);
            GameDirector.GetComponent<Mart_ControlUI>().ChangeFlagTrue();

            ShowOX.GetComponent<Mart_ControlOX>().ShowO();
        }
        if (collidObj.tag == "Mart_Item6" && answer != 5)
        {
            Debug.Log("����");

            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }



    }


}
