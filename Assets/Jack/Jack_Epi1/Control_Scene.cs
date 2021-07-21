/*
 * - Name : Control_Scene.cs
 * - Writer : 최대준
 * - Content : 잭과콩나무 에피소드1 - 
 * -기록-
 * 2021-07-21 : 작성
 * GetMouseButtonUp(0) : 좌클릭시 true 반환 하는 함수
 * SceneManager.LoadScene("") : Scene 이동 하는 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_Scene : MonoBehaviour
{
    public string ms_loadScene;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            clickedMouse();
        }
    }
    void clickedMouse() {
        SceneManager.LoadScene(ms_loadScene);
    }
    
}
