/*
  * - Name : Movement_Giant.cs
  * - Writer : 이윤교
  * - Content : 잭과콩나무 에피소드13 - 화살표 깜빡이는 효과 스크립트
  * 
  *            -작성 기록-
  *            2021-07-14 : 제작 완료
  *
  * MoveTowards() : 등속 이동, 매개변수로 {현재위치, 목표위치, 속도}를 입력  
  *            
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkAni : MonoBehaviour
{
    float f_time;
    // Update is called once per frame
    public void Update()
    {
        /*깜빡깜빡 거리는 효과*/
        
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
