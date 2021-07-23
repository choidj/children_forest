/*
 * - Name : Collsion_nextpage.cs
 * - Writer : 류시온
 * - Content : 잭과콩나무 에피소드2 - 충돌시 다음 페이지로 넘어가는 스크립트
 *          -기록-
 *          2021-07-20 : 주석 작성.
 *          2021-07-23 : TTS 음성 출력 기능 추가.
 * - Collsion_nextpage Member variable
 * string ms_nameNextScene : 인스펙터 창에서 지정한 다음 씬의 이름을 저장하는 변수이다.
 * bool mb_playOnce = false : 음성이 한번만 출력하도록 체크하는 변수이다.
 * VoiceManager mvm_playVoice : 음성을 준비하고 출력하는 클래스이다.
 * - Collsion_nextpage Member function
 * OnTriggerEnter2D() : collider 충돌이 일어나면 다음 씬으로 넘어가도록 하였다.
 * Start() : 음성을 출력하기 위해서 VoiceManager를 초기화한다.
 * Update() : 음성이 준비가 되었다면 한번만 출력하도록 한다.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 해당하는 오브젝트가 충돌이 일어나면 다음 지정한 씬으로 넘어가도록 하였다.
public class Collision_nextpage : MonoBehaviour
{
    public string ms_nameNextScene;
    public bool mb_playOnce = false;
    private VoiceManager mvm_playVoice;

    void Start() {
        mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }
    // 음성은 한번만 출력되도록 한다.
    void Update() {
        if(mvm_playVoice.mb_checkSceneReady && !mb_playOnce) {
            mvm_playVoice.playVoice(0);
            mb_playOnce = true;
        }
    }
    // 충돌시에 호출되는 함수이다. 음성이 끝났다면, 지정한 다음 씬으로 넘어간다.
    void OnTriggerEnter2D(Collider2D cCollideObject) {
        if(!mvm_playVoice.isPlaying()) {
            SceneManager.LoadScene(ms_nameNextScene);
        }
    }
    // 충돌중에 호출되는 함수이다. 음성이 끝났다면, 지정한 다음 씬으로 넘어간다.
    void OnTriggerStay2D(Collider2D cCollideObject) {
        if(!mvm_playVoice.isPlaying()) {
            SceneManager.LoadScene(ms_nameNextScene);
        }
    }
}
