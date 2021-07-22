/*
 * - Name : ShowEffect.cs
 * - Writer : 최대준
 * - Content : ShowEffect 클래스에서는 이름에서와 같이 씬에 필요한 이펙트 프리팹을 일정시간만큼 플레이어에게 노출시키고, 사라지도록 하는 클래스이다.
 * - Where the code is applied : null
 *             -사용법-
 *            1. 빈 게임 오브젝트에 스크립트 코드를 드래그하여 넣어주면 된다.
 *            -작성 기록-
 *            2021-07-19 : 제작 완료
 *            2021-07-20 : 주석 처리
 *
 * - ShowEffect Member Variable 
 * null : 아직 준비중인 스크립트 코드이다.
 * 
 * - ShowEffect Member Function
 * null : 아직 준비중인 스크립트 코드이다.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEffect : MonoBehaviour
{
    public GameObject mg_playEffectObj;

    // When the fruit collide basket, fruit will be disappeared.
    void OnTriggerEnter2D(Collider2D cCollideObject)
    {
        if (cCollideObject.tag == "PutFruitInBasket")
        {
            Instantiate(mg_playEffectObj, transform.position, Quaternion.identity);
            Destroy(mg_playEffectObj, 1f);
        }
    }
}
