using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct VoiceInfo {
    [SerializeField]
    public Voice svt_voiceType;

    [SerializeField]
    public string sstr_words;
        [SerializeField]
    public AudioClip sac_voiceAudioClip;
}
public enum VOICE_TYPE {

}
public class VoiceManager : MonoBehaviour {
    public VoiceInfo[] mvifl_setVoiceInfoList;
    private string[] msa_splitKRTexts;
    private string[] msa_splitENTexts;
    private int mn_saveIdLength;
    private TTS mtts_getVoice;
    private AudioSource mas_playVoice;

    // When fruitPutIn stage start, random initializing position of fruits.
    void Start() {
        mas_playVoice = gameObject.GetComponent<AudioSource>();
        mtts_getVoice = TTS.GetInstance();
        // //load the audio clips to need...
        for(int i = 0; i < mvifl_setVoiceInfoList.Length; i++) {
            mvifl_setVoiceInfoList[i].sac_voiceAudioClip = mtts_getVoice.CreateAudio(mvifl_setVoiceInfoList[i].sstr_words, mvifl_setVoiceInfoList[i].svt_voiceType);
        }
    }
    public void playVoice(int nPlayVoiceClipId) {
        mas_playVoice.PlayOneShot(mvifl_setVoiceInfoList[nPlayVoiceClipId].sac_voiceAudioClip);
    }
    // public void playVoice(FRUIT_TYPE ftPlayVoiceClip) {
    //     for(int i = 0; i < 10; i++) {
    //         if(i == (int)ftPlayVoiceClip) {
    //             if(i % 2 == 0) {
    //                 mas_playVoice.PlayOneShot(macl_KRsaveVoiceList[i/2]);
    //             }
    //             else
    //                 mas_playVoice.PlayOneShot(macl_ENsaveVoiceList[i/2]);
    //         }
    //     }
    // }
}
