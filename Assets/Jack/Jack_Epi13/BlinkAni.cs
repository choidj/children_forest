using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkAni : MonoBehaviour
{
    float f_time;
    // Update is called once per frame
    void Update()
    {
        if (f_time < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            if (f_time > 1f)
                f_time = 0;
        }
        f_time += Time.deltaTime;
    }

}
