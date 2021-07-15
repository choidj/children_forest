using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMom : MonoBehaviour
{
    public GameObject Mom;
    public GameObject Ax;
    public Vector3 target;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
    }
    void OnTriggerEnter2D(Collider2D cCollideObject){
        if (cCollideObject.tag == "Ax"){
            Color tempColor = Ax.GetComponent<SpriteRenderer>().color;
            tempColor.a = 1f;
            Ax.GetComponent<SpriteRenderer>().color = tempColor;
        }
    }
}
