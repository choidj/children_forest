using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mart_RandomItem : MonoBehaviour
{

    GameObject RandomItem;
    public Sprite[] sprites = new Sprite[6];

    GameObject GameDirector;

    int RandomValue;
    int leftTime;
    bool ItemFlag;



    // Start is called before the first frame update
    void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector");
        this.RandomItem = GameObject.Find("Mart_RandomItem");

        RandomValue = GameDirector.GetComponent<Mart_ControlUI>().Mart_RandomItemValue();
        this.RandomItem.GetComponent<SpriteRenderer>().sprite = sprites[RandomValue];

        ItemFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        ItemFlag = GameDirector.GetComponent<Mart_ControlUI>().checkFlag();
        if (ItemFlag == true)
        {
            leftTime = GameDirector.GetComponent<Mart_ControlUI>().HowmanyleftArr();
            if(leftTime != 0)
            {
                RandomValue = GameDirector.GetComponent<Mart_ControlUI>().Mart_RandomItemValue();
                this.RandomItem.GetComponent<SpriteRenderer>().sprite = sprites[RandomValue];


                GameDirector.GetComponent<Mart_ControlUI>().ChangeFlagFalse();
            }
            else if(leftTime == 0)
            {
                SceneManager.LoadScene("end_scene");
            }


            
        }

    }


    public int Answer()
    {
        return RandomValue;
    }
}
