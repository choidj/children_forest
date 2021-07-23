/*
 * - Name : ControlScene_JackEpi1.cs
 * - Writer : 최대준
 * - Content : 잭과콩나무 에피소드1 - 
 *          -기록-
 *          2021-07-20 : 주석 작성.
 *          2021-07-23 : TTS 음성 출력 기능 추가.
 * - ControlScene_JackEpi1 Member variable
 * string ms_loadScene : 다음 씬을 인스펙터창에서 입력하도록 하여 저장하는 변수이다.
 * bool mb_playOnce = false : 음성이 한번만 출력하도록 체크하는 변수이다.
 * VoiceManager mvm_playVoice : 음성을 준비하고 출력하는 클래스이다.
 * - ControlScene_JackEpi1 Member function
 * GetMouseButtonUp(0) : 좌클릭시 clickedMouse 함수를 호출하는 함수.
 * SceneManager.LoadScene("") : 다음 Scene으로 이동 하는 함수.
 * Start() : 음성을 출력하기 위해서 VoiceManager를 초기화한다.
 * Update() : 음성이 준비가 되었다면 한번만 출력하도록 한다.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 잭과 콩나무 첫번째 씬에서 다음 씬으로 넘어가는 클래스이다.
public class ControlScene_JackEpi1 : MonoBehaviour {
    public string ms_loadScene;
    public bool mb_playOnce = false;
    private VoiceManager mvm_playVoice;
    void Start() {
        mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }
    // 씬에서 플레이어가 좌클릭하는 것을 감지하면, clickedMouse 함수를 호출한다.
    void Update() {
        if(mvm_playVoice.mb_checkSceneReady && !mb_playOnce) {
            mvm_playVoice.playVoice(0);
            mb_playOnce = true;
        }
        if(!mvm_playVoice.isPlaying()) {
            if (Input.GetMouseButtonUp(0)) {
                clickedMouse();
            }
        }

    }
    // 이 함수가 호출되면 다음 씬으로 넘어가도록 하였다.
    void clickedMouse() {
        SceneManager.LoadScene(ms_loadScene);
    }
    
}
