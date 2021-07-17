using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FRUIT_TYPE {
    APPLE_KR,
    APPLE_EN,
    STRAW_KR,
    STRAW_EN,
    FINE_KR,
    FINE_EN,
    GRAPE_KR,
    GRAPE_EN,
    BANANA_KR,
    BANANA_EN
}
public class VoiceManager : MonoBehaviour
{
    // Start is called before the first frame update

    private TTS mtts_getFruitNameVoice;
    private AudioClip[] macl_ENsaveFruitNameVoiceList = new AudioClip[5];
    private AudioClip[] macl_KRsaveFruitNameVoiceList = new AudioClip[5];
    private AudioSource mas_playVoice;

    // When fruitPutIn stage start, random initializing position of fruits.
    void Start() {
        mas_playVoice = gameObject.GetComponent<AudioSource>();
        mtts_getFruitNameVoice = TTS.GetInstance(Voice.KR_FEMALE_A);

        macl_KRsaveFruitNameVoiceList[0] = mtts_getFruitNameVoice.CreateAudio("딸기");
        macl_KRsaveFruitNameVoiceList[1] = mtts_getFruitNameVoice.CreateAudio("사과");
        macl_KRsaveFruitNameVoiceList[2] = mtts_getFruitNameVoice.CreateAudio("파인애플");
        macl_KRsaveFruitNameVoiceList[3] = mtts_getFruitNameVoice.CreateAudio("포도");
        macl_KRsaveFruitNameVoiceList[4] = mtts_getFruitNameVoice.CreateAudio("바나나");
        mtts_getFruitNameVoice = TTS.GetInstance(Voice.EN_FEMALE_A);
        macl_ENsaveFruitNameVoiceList[0] = mtts_getFruitNameVoice.CreateAudio("Strawberry");
        macl_ENsaveFruitNameVoiceList[1] = mtts_getFruitNameVoice.CreateAudio("Apple");
        macl_ENsaveFruitNameVoiceList[2] = mtts_getFruitNameVoice.CreateAudio("Fine Apple");
        macl_ENsaveFruitNameVoiceList[3] = mtts_getFruitNameVoice.CreateAudio("Grape");
        macl_ENsaveFruitNameVoiceList[4] = mtts_getFruitNameVoice.CreateAudio("Banana");
        for(int i = 0; i < 5; i++) {
            Debug.Log(macl_KRsaveFruitNameVoiceList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playVoice(FRUIT_TYPE ftPlayVoiceClip) {
        for(int i = 0; i < 10; i++) {
            if(i == (int)ftPlayVoiceClip) {
                if(i % 2 == 0) {
                    mas_playVoice.PlayOneShot(macl_KRsaveFruitNameVoiceList[i/2]);
                }
                else
                    mas_playVoice.PlayOneShot(macl_ENsaveFruitNameVoiceList[i/2]);
            }
        }
    }
}
