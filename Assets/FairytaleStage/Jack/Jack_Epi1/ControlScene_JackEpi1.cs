﻿/*
 * - Name : ControlScene_JackEpi1.cs
 * - Writer : 최대준
 * - Content : 잭과콩나무 에피소드1 - 
 *          -기록-
 *          2021-07-21 : 작성
 * - ControlScene_JackEpi1 Member variable
 * string ms_loadScene : 다음 씬을 인스펙터창에서 입력하도록 하여 저장하는 변수이다.
 * - ControlScene_JackEpi1 Member function
 * GetMouseButtonUp(0) : 좌클릭시 clickedMouse 함수를 호출하는 함수.
 * SceneManager.LoadScene("") : 다음 Scene으로 이동 하는 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 잭과 콩나무 첫번째 씬에서 다음 씬으로 넘어가는 클래스이다.
public class ControlScene_JackEpi1 : MonoBehaviour {
    public string ms_loadScene;
    // 씬에서 플레이어가 좌클릭하는 것을 감지하면, clickedMouse 함수를 호출한다.
    void Update() {
        if (Input.GetMouseButtonUp(0)) {
            clickedMouse();
        }
    }
    // 이 함수가 호출되면 다음 씬으로 넘어가도록 하였다.
    void clickedMouse() {
        SceneManager.LoadScene(ms_loadScene);
    }
    
}