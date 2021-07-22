/*
 * - Name : Collsion_nextpage.cs
 * - Writer : 류시온
 * - Content : 잭과콩나무 에피소드2 - 충돌시 다음 페이지로 넘어가는 스크립트
 * -기록-
 * 2021-07-20 : 작성
 * OnTriggerEnter2D(Collider2D cCollideObject) : 오브젝트간 충돌이 일어날때 처음 한번만 호출되는 함수
 * SceneManager.LoadScene(ms_nameNextScene) : 오브젝트간 충돌시 다음 씬(작성된 위치)로 넘어가는 함수
 * 
 */
/*
 * - Name : Collsion_nextpage.cs
 * - Writer : 류시온
 * - Content : 잭과콩나무 에피소드2 - 충돌시 다음 페이지로 넘어가는 스크립트
 *          -기록-
 *          2021-07-20 : 작성
 * - Collsion_nextpage Member variable
 * string ms_nameNextScene : 인스펙터 창에서 지정한 다음 씬의 이름을 저장하는 변수이다.
 * - Collsion_nextpage Member function
 * OnTriggerEnter2D() : collider 충돌이 일어나면 다음 씬으로 넘어가도록 하였다.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 해당하는 오브젝트가 충돌이 일어나면 다음 지정한 씬으로 넘어가도록 하였다.
public class Collision_nextpage : MonoBehaviour
{

    public string ms_nameNextScene;
    // 충돌시에 호출되는 함수이다. 지정한 다음 씬으로 넘어간다.
    void OnTriggerEnter2D(Collider2D cCollideObject)
    {
        SceneManager.LoadScene(ms_nameNextScene);
    }
}
