/*
 * - Name : Jack4_Blink.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 반짝이는 효과를 주는 스크립트
 * 
 * -Update Log-
 * 2021-07-16 : 제작완료
 * 2021-07-21 : 주석 변경
 *                  
 * - Variable 
 * f_time : 시간 측정을 위한 변수
 * 
 * -Function()
 * v_StartBlink() : 반짝이는 효과를 제공해주는 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack4_Blink : MonoBehaviour
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

    /// <summary>
    /// 반짝이는 효과를 제공해주는 함수
    /// </summary>
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
