using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private float shakeTime; //카메라 흔들림 지속시간 (설정하지 않으면 default 1.0f)
    private float shakeIntensity; //카메라 흔들림 세기 (값이 클수록 세게 흔들림, 설정하지 않으면 default 1.0f)

    //Summary
    //외부에서 카메라 흔들림을 조작할 때 호출하는 메소드
    //ex) OnShakeCamera(1); -> 1초간 0.1의 세기로 흔들림
    //ex) OnShakeCamera(0.5f,1); -> 0.5chrks 1의 세기로 흔들림
    private void Update(){
        OnShakeCamera(0.1f,1f);
    }
    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 1.0f){
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    //카메라를 shakeTime동안 shakeIntensity의 세기로 흔드는 코루틴 함수
    private IEnumerator ShakeByPosition(){
        Vector3 startPosition = transform.position; //흔들기 직전의 시작위치 (흔들림종료 후 돌아올 위치)
        while (shakeTime < 2.0f){
            //회전하길 원하는 축만 지정해서 사용 (회전하지 않을 축은 0으로 설정)
            // float x = 0; //Random.Range(-1f,1f);
            // float y = 0; //Random.Range(-1f,1f);
            // float z = Random.Range(-1f,1f);
            // transform.rotation = Quaternion.Euler(startRotation + new Vector3(x,y,z) * shakeIntensity * power);
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;
            //시간 감소
            shakeTime -= Time.deltaTime;
            yield return null;
        }
        //흔들리기 직전의 회전 값으로 설정
        transform.position = startPosition;
    }
}
 