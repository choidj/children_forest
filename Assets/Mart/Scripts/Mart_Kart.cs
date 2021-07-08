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
<<<<<<< Updated upstream
=======
        this.ShowOX = GameObject.Find("ShowOX");
        this.Mart_RandomItem = GameObject.Find("Mart_RandomItem");

>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    void OnTriggerEnter2D(Collider2D collidObj)
    {
        if (collidObj.tag == "Mart_Item1")
        {
            Debug.Log("Mart_Item1 삭제");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(0);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
<<<<<<< Updated upstream
            
            
            //GameDirector.GetComponent<Mart_ControlUI>().testqq();
=======
            Destroy(collidObj.gameObject);
            GameDirector.GetComponent<Mart_ControlUI>().ChangeFlagTrue();

            ShowOX.GetComponent<Mart_ControlOX>().ShowO();

            //GameDirector.GetComponent<Mart_ControlUI>().testqq();
        }
        if(collidObj.tag == "Mart_Item1" && answer != 0)
        {
            Debug.Log("오답");
         
            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

>>>>>>> Stashed changes
        }
        if (collidObj.tag == "Mart_Item2")
        {
            Debug.Log("Mart_Item2 삭제");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(1);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
        }
<<<<<<< Updated upstream
        if (collidObj.tag == "Mart_Item3")
=======
        if (collidObj.tag == "Mart_Item2" && answer != 1)
        {
            Debug.Log("오답");

            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }
        if (collidObj.tag == "Mart_Item3" && answer == 2)
>>>>>>> Stashed changes
        {
            Debug.Log("Mart_Item3 삭제");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(2);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
        }
<<<<<<< Updated upstream
        if (collidObj.tag == "Mart_Item4")
=======
        if (collidObj.tag == "Mart_Item3" && answer != 2)
        {
            Debug.Log("오답");

            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }
        if (collidObj.tag == "Mart_Item4" && answer == 3)
>>>>>>> Stashed changes
        {
            Debug.Log("Mart_Item4 삭제");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(3);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
        }
<<<<<<< Updated upstream
        if (collidObj.tag == "Mart_Item5")
=======
        if (collidObj.tag == "Mart_Item4" && answer != 3)
        {
            Debug.Log("오답");

            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }
        if (collidObj.tag == "Mart_Item5" && answer == 4)
>>>>>>> Stashed changes
        {
            Debug.Log("Mart_Item5 삭제");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(4);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
        }
<<<<<<< Updated upstream
        if (collidObj.tag == "Mart_Item6")
=======
        if (collidObj.tag == "Mart_Item5" && answer != 4)
        {
            Debug.Log("오답");

            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }
        if (collidObj.tag == "Mart_Item6" && answer == 5)
>>>>>>> Stashed changes
        {
            Debug.Log("Mart_Item6 삭제");

            GameDirector.GetComponent<Mart_ControlUI>().Mart_CheckRandomItemArr(5);
            LeftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
        }
        if (collidObj.tag == "Mart_Item6" && answer != 5)
        {
            Debug.Log("오답");

            ShowOX.GetComponent<Mart_ControlOX>().ShowX();

        }


        Destroy(collidObj.gameObject);
        GameDirector.GetComponent<Mart_ControlUI>().ChangeFlagTrue();
    }


}
