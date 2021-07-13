using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJack : MonoBehaviour
{
    float timer;
    int waitingTime;

    public Vector3 target = new Vector3(-2.1f, -3.57f, 0);

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
        }

    }
}
