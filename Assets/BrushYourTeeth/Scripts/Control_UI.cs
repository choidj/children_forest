using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class Control_UI : MonoBehaviour
{

    GameObject NumberOfVirusLeft;
    GameObject Virus1;

    private int LeftVirus = 10;  //남은 바이러스 수

    // Start is called before the first frame update
    void Start()
    {
        this.NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");

    }

    
    public void MinusVirus()
    {
        this.LeftVirus -= 1;
        Debug.Log("남은 바이러스 수 1 감소");
        Debug.Log(this.LeftVirus);


    }
    
    // Update is called once per frame
    void Update()
    {
        this.NumberOfVirusLeft.GetComponent<Text>().text = "남은 바이러스 수 : " + this.LeftVirus;


        if (this.LeftVirus == 0)
        {
            SceneManager.LoadScene("end_scene");
        }

    }

}
