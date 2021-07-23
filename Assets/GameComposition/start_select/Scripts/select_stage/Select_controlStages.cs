/*
 * - Name : Select_controlStages.cs
 * - Writer : 최대준
 * - Content : 스테이지 선택 화면으로, 각각 스테이지를 플레이어가 클릭하게 되면, 그에 맞는 스테이지 화면으로 넘어가게끔 만들었다.
 *          -기록-
 *          2021-07-09 : 코드 완성
 *          2021-07-22 : 코드 수정 (LoadingScene 클래스를 이용하여 Loading 행위 구현)
 *          2021-07-22 : 주석 작성
 * - Select_controlStages Member variable
 * null
 * - Select_controlStages Member function
 * Update() : 플레이어가 스테이지를 선택하는 행위를 감지하여 선택한 스테이지에 맞게 씬을 전환하게 하였다.
 * SceneManager.LoadScene() : 다음 Scene으로 이동 하는 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 플레이어가 스테이지를 선택하는 행위를 감지하여 선택한 스테이지에 맞게 씬을 전환하게 하도록 하기 위한 클래스.
public class Select_controlStages : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ra_checkMouseDistance = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D h_hitDistanceCast2D = Physics2D.GetRayIntersection(ra_checkMouseDistance, Mathf.Infinity);

            if (h_hitDistanceCast2D.collider != null && h_hitDistanceCast2D.collider.tag == "Stage")
            {
                string[] strTmp = h_hitDistanceCast2D.collider.name.Split('_');
                switch (strTmp[0])
                {
                    case "brush":
                        LoadingScene.v_loadScene("clean_teeth_scene");
                        break;
                    case "mart":
                        LoadingScene.v_loadScene("buy_mart_scene");
                        break;
                    case "match":
                        LoadingScene.v_loadScene("match_shape_scene");
                        break;
                    case "puzzle":
                        LoadingScene.v_loadScene("solve_puzzle_scene");
                        break;
                    case "reading":
                        LoadingScene.v_loadScene("Jack_Epi1");
                        break;
                    case "fruit":
                        SceneManager.LoadScene("put_fruits_scene");
                        break;
                    case "lock":
                        Debug.Log("lock stage is clicked.....");
                        break;
                }
            }
        }
    }
}
