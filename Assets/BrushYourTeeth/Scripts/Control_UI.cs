using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Control_UI : MonoBehaviour
{

    GameObject NumberOfVirusLeft;
    GameObject Virus1;

    public int LeftVirus = 10;  //���� ���̷��� ��

    // Start is called before the first frame update
    void Start()
    {
        this.NumberOfVirusLeft = GameObject.Find("NumberOfVirusLeft");

    }

    
    public void MinusVirus()
    {
        this.LeftVirus -= 1;
        Debug.Log("���� ���̷��� �� 1 ����");
        Debug.Log(this.LeftVirus);


    }
    
    // Update is called once per frame
    void Update()
    {
        this.NumberOfVirusLeft.GetComponent<Text>().text = "���� ���̷��� �� : " + this.LeftVirus;

    }

}
