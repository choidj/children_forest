/*
 * - Name : Mart_ControlOX.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 정답에 따라 O 또는 X 를 보여주는 스크립트
 * 
 * -Update Log-
 * 2021-07-08 : 제작 완료
 * 2021-07-09 : 코드 정리
 * 2021-07-20 : 인코딩형식 수정 및 주석 수정
 * 2021-07-21 : 정답 또는 오답시 음성기능 추가
 *                  
 * - Variable 
 * mg_O : O 프리팹을 연결해주는 변수
 * mg_X : X 프리팹을 연결해주는 변수
 * vm : TTS 오브젝트 연결을 위한 변수
 * 
 * -Function()
 * v_ShowO() : O 를 보여주는 스크립트
 * v_ShowX() : X 를 보여주는 스크립트
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mart_ControlOX : MonoBehaviour{
    public GameObject mg_O;
    public GameObject mg_X;
    VoiceManager vm;

    void Start(){
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();     // TTS 오브젝트 연결
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
        vm.playVoice(0);                                            // TTS 작동
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
        vm.playVoice(1);                                            // TTS 작동
        Destroy(show,1);                                            // 이미지를 띄우고 삭제하는 텀을 변경하고 싶으면 이 부분 수정
        Debug.Log("mg_X이미지 삭제");
    }
}
