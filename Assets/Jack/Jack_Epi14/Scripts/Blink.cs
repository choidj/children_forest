using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    float f_time;
    float timer;
    float waitingTime;
    void Start(){
        timer = 0.0f;
        waitingTime = 3f;
    }
    public void Update()
    {
        timer += Time.deltaTime;
        if(timer > waitingTime){
            if (f_time < 0.5f){
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
            else{
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                if (f_time > 1f)
                    f_time = 0;
            }
            f_time += Time.deltaTime;
        }
    }
}
