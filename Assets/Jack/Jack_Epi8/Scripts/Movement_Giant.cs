using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Giant : MonoBehaviour
{   
    public GameObject targetPosition;
    void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, 0.1f);        
    }
}