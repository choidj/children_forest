/*
 * - Name : Collsion_nextpage.cs
 * - Writer : 류시온
 * - Content : 잭과콩나무 에피소드2 - 충돌시 다음 페이지로 넘어가는 스크립트
 * -기록-
 * 2021-07-20 : 작성
 * OnTriggerEnter2D(Collider2D cCollideObject) :오브젝트간 충돌이 일어날때 처음 한번만 호출되는 함수
 * SceneManager.LoadScene(ms_nameNextScene) : 오브젝트간 충돌시 다음 씬(작성된 위치)로 넘어가는 함수,
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_nextpage : MonoBehaviour
{
    public string ms_nameNextScene;
    void OnTriggerEnter2D(Collider2D cCollideObject)
    {
        SceneManager.LoadScene(ms_nameNextScene);
    }
}
