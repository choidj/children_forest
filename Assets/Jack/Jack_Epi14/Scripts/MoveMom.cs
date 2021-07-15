using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMom : MonoBehaviour
{
    GameObject Ax, Jack, Mom;
    Vector3 MomPos;
    void Start() {
        Ax = GameObject.Find("Ax");
        Jack = GameObject.Find("Jack");
        Mom = GameObject.Find("Mom");
        MomPos = new Vector3(-3,-1.14f,0);
    }
    void Update()
    {
        Mom.transform.position = Vector3.MoveTowards(Mom.transform.position, MomPos, 0.1f);
    }
    void OnTriggerEnter2D(Collider2D cCollideObject){
        if (cCollideObject.tag == "Ax"){
            Color tempColor = Ax.GetComponent<SpriteRenderer>().color;
            tempColor.a = 1f;
            Ax.GetComponent<SpriteRenderer>().color = tempColor;
        }
    }
}