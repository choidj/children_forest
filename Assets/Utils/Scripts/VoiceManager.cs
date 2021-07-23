/*
 * - Name : VoiceManager.cs
 * - Writer : 최대준
 * - Content : Text to Speech Class를 통해 최종적으로 AudioClip을 통해 음성을 출력하는 클래스이다. 여기서는 협업을 통해 작업하기 쉽도록 음성 세팅을 인스펙터에서 할 수 있도록 설정하게 되었다. 덕분에 VoiceManager 라는 프리팹 하나만 각각 씬으로 가져가 음성 세팅하고, 씬에 있는 스크립트 코드에 따라 VoiceManager 클래스의 playVoice함수만 호출해 주면 음성이 출력된다.
 * - Where the code is applied : /Asset/fruit_putin/Scenes/put_fruits_scene -> VoiceManager
 *             -사용법-
 *            1. VoiceManager라는 오브젝트를 프리팹으로 만들어두었다. 그것을 이용해서 쓰기만 하면 된다.
 *            2. VoiceManager 클래스의 안을 보자면, TTS 클래스를 선언한다. ex) TTS mtts_testTTS;
 *            3. TTS 클래스는 싱글톤 패턴이기 때문에 이미 사용중인 인스턴스가 있는지 확인하고 없으면 초기화한 인스턴스를 반환하는 함수를 호출한다. ex) mtts_textTTS = TTS.getInstance();
 *            4. VoiceManager는 인스펙터로 만들 보이스를 받아들이고 보이스를 TTS 클래스에서 구글 api를 통해서 audioclip으로 반환받게 된다.
 *            5. VoiceManager클래스는 AudioClip형태로 오디오를 가지고 있고, 클래스 안의 함수인 playVoice(id)함수를 통해서 음성을 씬에 출력하게 된다.
 *            -작성 기록-
 *            2021-07-19 : 제작 완료
 *            2021-07-20 : 주석 처리
 *            2021-07-22 : thread에게 TTS 통신 처리 위임, TTS 통신 처리 중에 로드 화면 추가.
 *            2021-07-23 : isPlaying() 함수 추가.
 *
 * - VoiceManager Member Variable 
 * VoiceInfo[] mvifl_setVoiceInfoList : 인스펙터창에서 음성 커스터마이징 할 수 있는 정보를 가진 struct 데이터이다. 구조체 안을 보면, {
    public Voice svt_voiceType : 원하는 구글 TTS API의 기본 보이스를 설정하는 enum 데이터이다. 필요한 데이터만 정리를 하여 쓸것만 enum형식으로 재구성 하였다. enum 종류로는, KR_FEMALE_A, KR_FEMALE_B, KR_MALE_A, KR_MALE_B, EN_FEMALE_A, EN_FEMALE_B, EN_MALE_A, EN_MALE_B로 구성되어 있다.
    public string sstr_words : 음성이 무슨 말을 출력할지를 string 형식으로 저장하는 변수이다.
    public float sf_pitch : 음성의 음조(높낮이)를 조절하는 변수이다.
    public string sf_speakingRate : 음성의 말 빠르기를 조절하는 변수이다.
    public AudioClip sac_voiceAudioClip : 최종적으로 TTS 와의 통신으로 받아낸 음성 데이터를 저장하는 변수이다.
 }
 * TTS mtts_getVoice : TTS 통신을 정의한 클래스이다.
 * AudioSource mas_playVoice : 최종적으로 반환받은 AudioClip을 이 유니티 컴포넌트 클래스를 통하여 씬에 출력하게 된다.
 * GameObject mc_loadingScene : TTS 통신 중이라면, 이 변수에 저장된 프리팹을 생성하도록 하는 변수이다..
 * GameObject mgo_loadingScene : 위의 변수에서 생성된 인스턴스를 저장하는 변수이다.
 * int mn_checkCurInx : 스레드의 작업물의 결과로 인덱싱하기 위해서 필요한 변수이다.
 * Queue<float[]> mquefa_queue : 메인 스레드와 생성된 스레드의 데이터 통신을 위한 큐로, 생성된 스레드는 이 큐에 작업물을 저장하게 되며, 그때 메인 스레드에서는 이 작업물을 통해 음성을 만들게 된다.
 * Thread mth_workThread : 위에서 언급된 생성된 스레드이다. TTS 통신을 대신 작업하게 된다.
 * bool mb_checkSceneReady : 작업이 다 끝났다면 true로 만들어 다른 스크립트에서 감지할 수 있게 해주는 변수이다.
 * 
 * - VoiceManager Member Function
 * Start() : VoiceManager 게임 오브젝트가 생성될 때 최초로 실행되는 함수로, 인스펙터 창에 입력된 음성 세팅값들을 통해 씬에서 필요한 음성 데이터를 만든다.
 * playVoice(int nPlayVoiceClipId) : 생성된 음성 데이터를 가지고 있다가 이 함수가 호출되면 음성을 씬에 출력한다.
 * isPlaying() : 현재 AudioSource를 통해 음성이 출력되고 있는지 아닌지를 반환해주는 함수. 출력되고 있다면 true, 아니라면 false를 반환한다.
 * runThread() : mth_workThread 스레드의 TTS 처리 코드가 실행되는 함수. 작업된 float array 반환 값은 mquefa_queue 큐에 저장하게 된다.
 * Update() : 메인 스레드에서는 업데이트 함수를 통해 mquefa_queue에 데이터가 쌓이면, 그것을 가지고 AudioClip으로 만들고 mvifl_setVoiceInfoList struct 안의 sac_voiceAudioClip에 저장하게 된다.
 */

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

// 인스펙터창에 입력되는 음성 세팅 값을 저장하는 struct이다.
[System.Serializable]
public struct VoiceInfo {
    [SerializeField]
    public Voice svt_voiceType;

    [SerializeField]
    public string sstr_words;
    [SerializeField]
    public float sf_pitch;
    public string sf_speakingRate;
    [SerializeField]
    public AudioClip sac_voiceAudioClip;
}
// 씬에서 음성을 출력하는 게임오브젝트에 적용되는 VoiceManager 클래스이다.
public class VoiceManager : MonoBehaviour {
    public VoiceInfo[] mvifl_setVoiceInfoList;
    public GameObject mc_loadingScene;
    private GameObject mgo_loadingScene;
    private int mn_checkCurInx = 0;
    private TTS mtts_getVoice;
    private Queue<float[]> mquefa_queue = new Queue<float[]>();
    private AudioSource mas_playVoice;
    private Thread mth_workThread;
    public bool mb_checkSceneReady = false;

    // 해당 스크립트가 들어간 게임 오브젝트가 생성될 때, 인스펙터창에 저장된 음성 세팅 값들을 통해서 스레드를 하나 생성하여 TTS 통신 작업을 위임시킨다.
    void Start() {
        mgo_loadingScene = Instantiate(mc_loadingScene);
        mgo_loadingScene.SetActive(true);
        mas_playVoice = gameObject.GetComponent<AudioSource>();
        mtts_getVoice = TTS.GetInstance();
        mth_workThread = new Thread(runThread);
        mth_workThread.Start();
    }
    // 메인 스레드는 작업중인 스레드가 큐에 저장한 작업 결과물을 통해 음성을 만들게 된다.
    void Update() {
        if(mquefa_queue.Count > 0) {
            var fa_convertFloatArray = mquefa_queue.Dequeue();
            
            AudioClip ac_createAudioClip = AudioClip.Create("audioContent", fa_convertFloatArray.Length, 1, 44100, false);

            ac_createAudioClip.SetData(fa_convertFloatArray, 0);
            mvifl_setVoiceInfoList[mn_checkCurInx].sac_voiceAudioClip = ac_createAudioClip;

            mn_checkCurInx++;
            Debug.Log("queue data response index : " + mn_checkCurInx);
        }
        if(mn_checkCurInx == mvifl_setVoiceInfoList.Length) {
            Destroy(mgo_loadingScene);
            mb_checkSceneReady = true;
        }
    }
    // 생성된 스레드가 작업해야 하는 일을 정의한 함수이다.(TTS 통신)
    private void runThread() {
        float tempSpeakRate = 0.8f;
        //load the audio clips to need...
        for(int i = 0; i < mvifl_setVoiceInfoList.Length; i++) {
            if (float.TryParse(mvifl_setVoiceInfoList[i].sf_speakingRate, out tempSpeakRate)) {
                mquefa_queue.Enqueue(mtts_getVoice.CreateAudio(mvifl_setVoiceInfoList[i].sstr_words, mvifl_setVoiceInfoList[i].svt_voiceType, mvifl_setVoiceInfoList[i].sf_pitch, tempSpeakRate));
            }
            else {
                mquefa_queue.Enqueue(mtts_getVoice.CreateAudio(mvifl_setVoiceInfoList[i].sstr_words, mvifl_setVoiceInfoList[i].svt_voiceType, mvifl_setVoiceInfoList[i].sf_pitch));
            }
        }
    }
    // 이 함수를 통해 저장했고 해당되는 AudioClip을 씬에 출력하게 된다. 
    public void playVoice(int nPlayVoiceClipId) {
        mas_playVoice.PlayOneShot(mvifl_setVoiceInfoList[nPlayVoiceClipId].sac_voiceAudioClip);
    }
    // 음성이 출력되는지 확인, 출력되고 있다면 true, 출력되지 않고 있다면 false.
    public bool isPlaying() {
        return mas_playVoice.isPlaying;
    }
}
