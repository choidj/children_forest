using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJack : MonoBehaviour
{
    public Vector3 target = new Vector3(-2, -3.54f, 0);
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
    }
}
