/*
 * - Name : HarpjackCollision.cs
 * - Writer : 류시온
 * - Content : 잭과콩나무 에피소드12 - 잭,하프 드래그 스크립트
 *          -기록-
 *          2021-07-20 : 주석 작성.
 *          2021-07-23 : TTS 음성 출력 기능 추가.
*           2021-07-26 : 효과음 추가 완료 (이윤교)
 * - HarpDrag Member variable 
 * GameObject mg_talk_Prefab : 말풍선 오브젝트를 저장하는 변수이다.
 * bool mb_playOnce = false : 음성이 한번만 출력하도록 체크하는 변수이다.
 * VoiceManager mvm_playVoice : 음성을 준비하고 출력하는 클래스이다.
 * - HarpDrag Member function 
 * OnTriggerEnter2D(Collider2D cCollideObject) :오브젝트간 충돌이 일어날때 처음 한번만 호출되는 함수
 * OnMouseDrag() : 게임오브젝트를 마우스 드래그로 이동시키는 함수
 * Invoke("changeNextScene", 3f): 3초 뒤에 ("")해당 함수를 호출 하는 함수
 * changeNextScene() : ("") 해당 씬으로 넘어가는 함수
 * Start() : 음성을 출력하기 위해서 VoiceManager를 초기화한다.
 * Update() : 음성이 준비가 되었다면 한번만 출력하도록 한다.
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 하프와 잭이 충돌했을 시에 나타나는 결과를 구현한 클래스이다.
public class HarpJackCollision: MonoBehaviour
{
    public GameObject mg_talk_Prefab;
    public bool mb_playOnce = false;
    private VoiceManager mvm_playVoice;
    private AudioSource HarpSound;// 하프 소리
    // VoiceManager 클래스 초기화.
    void Start() {
        mvm_playVoice = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        HarpSound = GameObject.Find("HarpSound").GetComponent<AudioSource>();
    }
    // VoiceManager를 통해 음성이 준비가 되었다면, 음성을 한번만 출력.
    void Update() {
        if(mvm_playVoice.mb_checkSceneReady && !mb_playOnce) {
            mvm_playVoice.playVoice(0);
            mb_playOnce = true;
        }
    }
    // 하프와 잭이 충돌했을 시에, 말풍선 오브젝트를 생성하고, 3초뒤에 다음씬으로 이동하도록 하였다.
    void OnTriggerEnter2D(Collider2D cCollideObject){
        GameObject g_talk = Instantiate(mg_talk_Prefab) as GameObject;
        PlayHarp();
        Invoke("changeNextScene", 4f);
    }
    void changeNextScene() {
        SceneManager.LoadScene("Jack_Epi13");
    }
    void PlayHarp(){
        HarpSound.Play();
    }
}
