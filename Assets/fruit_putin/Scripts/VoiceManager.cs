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
 *
 * - VoiceManager Member Variable 
 * VoiceInfo[] mvifl_setVoiceInfoList : 인스펙터창에서 음성 커스터마이징 할 수 있는 정보를 가진 struct 데이터이다. 
 * TTS mtts_getVoice;
 * AudioSource mas_playVoice;
 * 
 * - VoiceManager Member Function
 * Start() : VoiceManager 게임 오브젝트가 생성될 때 최초로 실행되는 함수로, 인스펙터 창에 입력된 음성 세팅값들을 통해 씬에서 필요한 음성 데이터를 만든다.
 * playVoice(int nPlayVoiceClipId) : 생성된 음성 데이터를 가지고 있다가 이 함수가 호출되면 음성을 씬에 출력한다.
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
    private Queue<float[]> mqueac_queue = new Queue<float[]>();
    private AudioSource mas_playVoice;
    private Thread mth_workThread;
    public bool mb_checkSceneReady = false;

    // 해당 스크립트가 들어간 게임 오브젝트가 생성될 때, 인스펙터창에 저장된 음성 세팅 값들을 통해서 AudioClip을 가지고 있게 된다. 
    void Start() {
        mgo_loadingScene = Instantiate(mc_loadingScene);
        mgo_loadingScene.SetActive(true);
        mas_playVoice = gameObject.GetComponent<AudioSource>();
        mtts_getVoice = TTS.GetInstance();
        mth_workThread = new Thread(runThread);
        mth_workThread.Start();
    }
    void Update()
    {
        if(mqueac_queue.Count > 0)
        {
            var fa_convertFloatArray = mqueac_queue.Dequeue();
            
            AudioClip ac_createAudioClip = AudioClip.Create("audioContent", fa_convertFloatArray.Length, 1, 44100, false);

            ac_createAudioClip.SetData(fa_convertFloatArray, 0);
            mvifl_setVoiceInfoList[mn_checkCurInx].sac_voiceAudioClip = ac_createAudioClip;

            mn_checkCurInx++;
            Debug.Log("queue data response index : " + mn_checkCurInx);
        }
        if(mn_checkCurInx == mvifl_setVoiceInfoList.Length) {
            Destroy(mgo_loadingScene);
        }
    }
    private void runThread() {
        float tempSpeakRate = 0.8f;
        //load the audio clips to need...
        for(int i = 0; i < mvifl_setVoiceInfoList.Length; i++) {
            if (float.TryParse(mvifl_setVoiceInfoList[i].sf_speakingRate, out tempSpeakRate)) {
                mqueac_queue.Enqueue(mtts_getVoice.CreateAudio(mvifl_setVoiceInfoList[i].sstr_words, mvifl_setVoiceInfoList[i].svt_voiceType, mvifl_setVoiceInfoList[i].sf_pitch, tempSpeakRate));
            }
            else
            {
                mqueac_queue.Enqueue(mtts_getVoice.CreateAudio(mvifl_setVoiceInfoList[i].sstr_words, mvifl_setVoiceInfoList[i].svt_voiceType, mvifl_setVoiceInfoList[i].sf_pitch));
            }
        }
    }
    // 이 함수를 통해 저장했고 해당되는 AudioClip을 씬에 출력하게 된다. 
    public void playVoice(int nPlayVoiceClipId) {
        mas_playVoice.PlayOneShot(mvifl_setVoiceInfoList[nPlayVoiceClipId].sac_voiceAudioClip);
    }
}
