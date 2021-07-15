using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJack : MonoBehaviour
{
    public Vector3 target;

    void Update()
    {
        Vector3 velo = Vector3.zero;
	    transform.position = Vector3.Slerp(transform.position, target, 0.1f);

    }
}
