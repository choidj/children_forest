/*
 * - Name : ControlFruit.cs
 * - Writer : 최대준
 * - Content : ControlFruit 클래스에서는 이름에서와 같이 생성된 Fruit 프리팹을 컨트롤하기 위한 클래스이다. Fruit 프리팹을 사용자가 드래그하면 Fruit가 따라오고,
 * 
 *             -사용법-
 *            1. 
 *            2. VoiceManager 클래스의 안을 보자면, TTS 클래스를 선언한다. ex) TTS mtts_testTTS;
 *            3. TTS 클래스는 싱글톤 패턴이기 때문에 이미 사용중인 인스턴스가 있는지 확인하고 없으면 초기화한 인스턴스를 반환하는 함수를 호출한다. ex) mtts_textTTS = TTS.getInstance();
 *            4. VoiceManager는 인스펙터로 만들 보이스를 받아들이고 보이스를 TTS 클래스에서 구글 api를 통해서 audioclip으로 반환받게 된다.
 *            5. VoiceManager클래스는 AudioClip형태로 오디오를 가지고 있고, 클래스 안의 함수인 playVoice(id)함수를 통해서 음성을 씬에 출력하게 된다.
 *            -작성 기록-
 *            2021-07-19 : 제작 완료
 *            2021-07-20 : 주석 처리
 *
 * - ControlFruit Member Variable 
 * VoiceInfo[] mvifl_setVoiceInfoList : 인스펙터창에서 음성 커스터마이징 할 수 있는 정보를 가진 struct 데이터이다. 
 * TTS mtts_getVoice;
 * AudioSource mas_playVoice;
 * 
 * - ControlFruit Member Function
 * Start() : VoiceManager 게임 오브젝트가 생성될 때 최초로 실행되는 함수로, 인스펙터 창에 입력된 음성 세팅값들을 통해 씬에서 필요한 음성 데이터를 만든다.
 * playVoice(int nPlayVoiceClipId) : 생성된 음성 데이터를 가지고 있다가 이 함수가 호출되면 음성을 씬에 출력한다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFruit : MonoBehaviour {
    private VoiceManager mvm_voiceManager;
    public int mn_fruitId;
    private Vector2 mv2_remembPos;
    private bool mb_checkClickOnce = false;
    void Start() {
        mvm_voiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>() as VoiceManager;
        mv2_remembPos = gameObject.transform.position;

    }
    void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv2_remembPos, 2f * Time.deltaTime);
    }
    private void OnMouseDrag() {
        if(!mb_checkClickOnce) {
            mvm_voiceManager.playVoice(mn_fruitId); //한국 보이스 출력
            mb_checkClickOnce = true;
        }
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }
    void OnMouseUp() {
        mb_checkClickOnce = false;
    }
    public void setFruitId(int nId) {
        mn_fruitId = nId;
    }
}