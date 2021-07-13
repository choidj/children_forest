using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGiant : MonoBehaviour
{
    float timer;
    int waitingTime;

    public Vector3 target = new Vector3(-6, -0.43f, 0);

    private void Start()
    {
        timer = 0.0f;
        waitingTime = 1;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
        }

    }
}
