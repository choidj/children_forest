/*
 * - Name : FixedStartScene.cs
 * - Writer : 최대준
 * - Content : 어느 씬에서 플레이를 하던 본 스크립트에서 정의한 씬으로 이동하게 된다. 사용한 의도는 처음 씬을 고정시켜 intro 씬부터 시작하도록 한것이다.
 * 
 *             -사용법-
 *            1. main_scene에 controlScene 오브젝트에 적용되어 있으며, 디버그를 위해 씬 고정을  해제하려면, 이 스크립트 클래스 안의 코드를 주석처리하면 된다.
 *            -작성 기록-
 *            2021-07-26 : 주석 처리
 *
 * - FixedStartScene Member Variable 
 * null
 * 
 * - FixedStartScene Member Function
 * FirstLoad() : [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] 라는 어노테이션을 받는 함수로, 함수의 이름과 같이 첫번째로 로드되어 호출되는 함수이다. 이 함수를 통해서 intro라는 씬으로 이동하게 된다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 첫 번째로 화면에 표시되는 씬을 아래와 같은 씬으로 고정시킨다.
public class FixedStartScene : MonoBehaviour {
 
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    // // intro 씬을 첫 번째 씬으로 고정시킨다.
    // static void FirstLoad()
    // {
    //     if (SceneManager.GetActiveScene().name.CompareTo("intro") != 0){
    //         SceneManager.LoadScene("intro");
    //     }
    // }

}
