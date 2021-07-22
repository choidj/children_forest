/*
  * - Name : Blink.cs
  * - Writer : 이윤교
  * - Content : 잭과콩나무 에피소드14 - 화살표 깜빡이는 효과 스크립트
  * 
  *            -작성 기록-
  *            2021-07-15 : 제작 완료
  *
  *
  *            
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{

    float mf_time; //깜빡거리는 속도
    float mf_timer;//현재 시간
    float mf_waitingTime; //원하는 시간 지정
    void Start(){
        mf_timer = 0.0f;
        mf_waitingTime = 4f;
    }
    public void Update()
    {
        mf_timer += Time.deltaTime;
        if(mf_timer > mf_waitingTime){
            if (mf_time < 0.3f){
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
            else{
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                if (mf_time > 1f)
                    mf_time = 0;
            }
            mf_time += Time.deltaTime;
        }
    }
}
