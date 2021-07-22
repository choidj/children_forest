using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack9_Blink : MonoBehaviour
{
    float f_time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        v_StartBlink();
    }

    public void v_StartBlink()
    {
        if (f_time < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            if (f_time > 1f)
                f_time = 0;
        }
        f_time += Time.deltaTime;
    }
}
