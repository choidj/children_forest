/*
 * - Name : HarpjackCollision.cs
 * - Writer : 류시온
 * - Content : 잭과콩나무 에피소드12 - 잭,하프 드래그 스크립트
 * -기록-
 * 2021-07-20 : 작성
 * OnTriggerEnter2D(Collider2D cCollideObject) :오브젝트간 충돌이 일어날때 처음 한번만 호출되는 함수
 * OnMouseDrag() : 게임오브젝트를 마우스 드래그로 이동시키는 함수
 * Invoke("changeNextScene", 3f): 3초 뒤에 ("")해당 함수를 호출 하는 함수
 * changeNextScene : ("") 해당 씬으로 넘어가는 함수
 */
/*
 * - Name : jack_cow_drag.cs
 * - Writer : 류시온
 * - Content : 잭과콩나무 에피소드2 - 잭,소 드래그 스크립트
 * -기록-
 * 2021-07-20 : 작성
 * OnTriggerEnter2D(Collider2D cCollideObject) :오브젝트간 충돌이 일어날때 처음 한번만 호출되는 함수
 * OnMouseDrag() : 게임오브젝트를 마우스 드래그로 이동시키는 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HarpJackCollision: MonoBehaviour
{
    public GameObject mg_talk_Prefab;


    void OnTriggerEnter2D(Collider2D cCollideObject)
    {
        GameObject g_talk = Instantiate(mg_talk_Prefab) as GameObject;
        Invoke("changeNextScene", 3f);
    }
    void changeNextScene() {
        SceneManager.LoadScene("Jack_Epi13");
    }
}
