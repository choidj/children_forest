using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private float shakeTime; //ī�޶� ��鸲 ���ӽð� (�������� ������ default 1.0f)
    private float shakeIntensity; //ī�޶� ��鸲 ���� (���� Ŭ���� ���� ��鸲, �������� ������ default 1.0f)

    //Summary
    //�ܺο��� ī�޶� ��鸲�� ������ �� ȣ���ϴ� �޼ҵ�
    //ex) OnShakeCamera(1); -> 1�ʰ� 0.1�� ����� ��鸲
    //ex) OnShakeCamera(0.5f,1); -> 0.5chrks 1�� ����� ��鸲
    private void Update(){
        OnShakeCamera(0.1f,1f);
    }
    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 1.0f){
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    //ī�޶� shakeTime���� shakeIntensity�� ����� ���� �ڷ�ƾ �Լ�
    private IEnumerator ShakeByPosition(){
        Vector3 startPosition = transform.position; //���� ������ ������ġ (��鸲���� �� ���ƿ� ��ġ)
        while (shakeTime < 2.0f){
            //ȸ���ϱ� ���ϴ� �ุ �����ؼ� ��� (ȸ������ ���� ���� 0���� ����)
            // float x = 0; //Random.Range(-1f,1f);
            // float y = 0; //Random.Range(-1f,1f);
            // float z = Random.Range(-1f,1f);
            // transform.rotation = Quaternion.Euler(startRotation + new Vector3(x,y,z) * shakeIntensity * power);
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;
            //�ð� ����
            shakeTime -= Time.deltaTime;
            yield return null;
        }
        //��鸮�� ������ ȸ�� ������ ����
        transform.position = startPosition;
    }
}
 