﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * - Name : BrushYourTeeth_ControlUI.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 정답에 따라 O 또는 X 를 보여주는 스크립트
 * 
 * -Update Log-
 * 2021-07-08 : 제작 완료
 * 2021-07-09 : 코드 정리
 *                  
 * - Variable 
 * mg_O : O 프리팹을 연결해주는 변수
 * mg_X : X 프리팹을 연결해주는 변수
 * 
 * -Function()
 * v_ShowO() : O 를 보여주는 스크립트
 * v_ShowX() : X 를 보여주는 스크립트
 */

public class Mart_ControlOX : MonoBehaviour{
    public GameObject mg_O;
    public GameObject mg_X;

    void Start(){
        
    }

    void Update(){
        
    }

    /// <summary>
    /// O를 보여주는 함수
    /// Destroy(show, n) : n 부분을 수정하여 이미지를 띄우고 삭제하는 텀을 변경할 수 있다.
    /// </summary>
    public void v_ShowO(){

        GameObject show = Instantiate(mg_O) as GameObject;
        show.transform.position = new Vector3(0, 0, 0);
        Debug.Log("mg_O이미지 생성");
        Destroy(show, 1);                                           // 이미지를 띄우고 삭제하는 텀을 변경하고 싶으면 이 부분 수정
        Debug.Log("mg_O이미지 삭제");
    }

    /// <summary>
    /// X를 보여주는 함수
    /// Destroy(show, n) : n 부분을 수정하여 이미지를 띄우고 삭제하는 텀을 변경할 수 있다.
    /// </summary>
    public void v_ShowX(){
        GameObject show = Instantiate(mg_X) as GameObject;
        show.transform.position = new Vector3(0, 0, 0);
        Debug.Log("mg_X이미지 생성");
        Destroy(show,1);                                            // 이미지를 띄우고 삭제하는 텀을 변경하고 싶으면 이 부분 수정
        Debug.Log("mg_X이미지 삭제");
    }
}
