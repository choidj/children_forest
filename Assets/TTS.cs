/*
 * - Name : TTS.cs
 * - Writer : 최대준
 * - Content : Text to Speech Class로, 디자인 패턴은 싱글톤 패턴을 이용하였다. 조금 무거운 클래스 이므로 하나의 인스턴스를 다른 오브젝트 클래스에서 재사용할 수 있도록 하기 위해서 싱글톤 패턴을 이용하였다.
 * 
*             -사용법-
*            1. VoiceManager라는 오브젝트를 프리팹으로 만들어두었다. 그것을 이용해서 쓰기만 하면 된다.
*            2. TTS 클래스를 선언한다. ex) TTS mtts_testTTS;
*            3. VoiceManager라는 클래스의 안을 살펴보자면,
*            4. 아래의 쓰여진 TTS 클래스는 싱글톤 패턴이기 때문에 이미 사용중인 인스턴스가 있는지 확인하고 없으면 초기화한 인스턴스를 반환하는 함수를 호출한다. ex) mtts_textTTS = TTS.getInstance();
*            5. VoiceManager는 인스펙터로 만들 보이스를 받아들이고 보이스를 TTS 클래스에서 구글 api를 통해서 audioclip으로 반환받게 된다.
*            6. VoiceManager클래스는 AudioClip형태로 오디오를 가지고 있고, 클래스 안의 함수인 playVoice(id)함수를 통해서 음성을 씬에 출력하게 된다.
*            -작성 기록-
*            2021-07-19 : 제작 완료
*            2021-07-20 : 주석 처리
 * - TTS Member Variable 
 * ms_useApiURL : Google TTS API 서버와 통신을 위한 URL 주소이다.
 * mstts_setTtsApi : Google TTS API 서버와 통신하여 데이터를 주고 받기 위한 데이터 형식을 맞춰주는 클래스이다. 이 안에는 보이스의 종류, 음조, 음성으로 바꿀 텍스트 등 음서으로 바꾸기 위해서 필요로 하는 세팅 데이터가 설정된다. 이때 이 세팅을 저장하는 이너클래스가 존재하는데, 각각 SetTextToSpeech, 
 * instance : 이 함수는 아무래도 통신을 하는 클래스로써, 무겁다고 작성자가 판단이 되어 클래스의 인스턴스를 계속 생산하는 것이 아니라, 싱글톤 디자인 패턴을 이용하여 하나의 인스턴스만 생성하게 만들었다. 이렇게 하면, 클래스의 인스턴스를 하나만 생성하여 여러 오브젝트 클래스들이 재사용할 수 있게 된다.
 * 
 * - TTS Member Function
 * v_NoneScript() : 스크립트를 공백으로 설정해준다.
 * v_NextScript() : 다음 스크립트를 보여준다.
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System;

public enum Voice
{
    KR_FEMALE_A,
    KR_FEMALE_B,
    KR_MALE_A,
    KR_MALE_B,
    EN_FEMALE_A,
    EN_FEMALE_B,
    EN_MALE_A,
    EN_MALE_B
}

public class TTS {
    //This is a single tone class...
    [System.Serializable]
    public class SetTextToSpeech {
        public SetInput input;
        public SetVoice voice;
        public SetAudioConfig audioConfig;
    }

    [System.Serializable]
    public class SetInput {
        public string text;
    }

    [System.Serializable]
    public class SetVoice {
        public string languageCode;
        public string name;
        //ssmlGender mean which voice is man or woman...
        public string ssmlGender;
    }


    [System.Serializable]
    public class SetAudioConfig {
        public string audioEncoding;
        public float speakingRate;
        public float pitch;
        public int volumeGainDb;
    }

    [System.Serializable]
    public class GetContent {
        public string audioContent;
    }

    private string ms_useApiURL = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=AIzaSyANPEwOXAhoxpeYwpJQBUkZRew42sI9ECU";
    private SetTextToSpeech mstts_setTtsApi;
    private static TTS instance = null;
    //constructor initialize these class..
    //initialize the json object config to send a google mstts_setTtsApi api.
    public TTS() {
        mstts_setTtsApi = new SetTextToSpeech();
    } 

    public static TTS GetInstance() {
        // 만약 instance가 존재하지 않을 경우 새로 생성한다.
        if (instance is null) {
            instance = new TTS();
        }
        // instance를 반환한다.
        return instance;
    }
    //convert the received byte array to float array...
    public AudioClip CreateAudio(string sTargetSpeech, Voice vTargetVoice, float fSetPitch = 0f, float fSpeakRate = 0.8f) {
        
        setAudioConfig(fSetPitch, fSpeakRate);
        setVoice(vTargetVoice);
        setInput(sTargetSpeech);

        //After request HttpWebRequest, save the returned data in string format.
        var s_str = TextToSpeechPost(mstts_setTtsApi);
        
        GetContent gc_Info = JsonUtility.FromJson<GetContent>(s_str);

        var ba_convertByteArray = Convert.FromBase64String(gc_Info.audioContent);
        var fa_convertFloatArray = ConvertByteToFloat(ba_convertByteArray);

        AudioClip ac_createAudioClip = AudioClip.Create("audioContent", fa_convertFloatArray.Length, 1, 44100, false);
        ac_createAudioClip.SetData(fa_convertFloatArray, 0);
        return ac_createAudioClip;
    }
    
    private static float[] ConvertByteToFloat(byte[] baArray) {
        float[] fa_tempFloatArr = new float[baArray.Length / 2];

        for(int i = 0; i < fa_tempFloatArr.Length; i++) {
            fa_tempFloatArr[i] = BitConverter.ToInt16(baArray, i*2) / 32768.0f;
        }
        return fa_tempFloatArr;
    }
    
    private string TextToSpeechPost(object oSendData) {
        //use JsonUtility. convert byte[] to send this string..
        string s_useJsonUTempStr = JsonUtility.ToJson(oSendData);
        Debug.Log(s_useJsonUTempStr);
        var b_checkbytesOftempStr = System.Text.Encoding.UTF8.GetBytes(s_useJsonUTempStr);

        //set address to request..
        HttpWebRequest hwr_requestApi = (HttpWebRequest)WebRequest.Create(ms_useApiURL);
        hwr_requestApi.Method = "POST";
        hwr_requestApi.ContentType = "application/json";
        hwr_requestApi.ContentLength = b_checkbytesOftempStr.Length;

        //send this data in Stream form.
        try {
            using (var stream = hwr_requestApi.GetRequestStream()) {
                stream.Write(b_checkbytesOftempStr, 0, b_checkbytesOftempStr.Length);
                stream.Flush();
                stream.Close();
            }

            //receiving the response data to request data in StreamReader format. 
            HttpWebResponse hwr_receiveResponse = (HttpWebResponse)hwr_requestApi.GetResponse();
            //read stream to StreamReader
            StreamReader sr_ReadStream = new StreamReader(hwr_receiveResponse.GetResponseStream());
            //convert stream data to string format.
            string s_outputJson = sr_ReadStream.ReadToEnd();
            Debug.Log(s_outputJson);
            return s_outputJson;
        }
        catch (WebException e){
            using (WebResponse response = e.Response)
            {
                HttpWebResponse httpResponse = (HttpWebResponse) response;
                Debug.Log(httpResponse.StatusCode);
                using (Stream data = response.GetResponseStream())
                using (var reader = new StreamReader(data))
                {
                    string text = reader.ReadToEnd();
                    Debug.Log(text);
                }
            }
            return null;
        }
    }
    private void setInput(string sTargetSpeech) {
        SetInput si_setInputData = new SetInput();
        si_setInputData.text = sTargetSpeech;
        mstts_setTtsApi.input = si_setInputData;
    }
    private void setAudioConfig(float fSetPitch, float fSpeakRate) {
        SetAudioConfig sa_setAudioConf = new SetAudioConfig();
        sa_setAudioConf.audioEncoding = "LINEAR16";
        sa_setAudioConf.speakingRate = fSpeakRate;
        sa_setAudioConf.pitch = fSetPitch;
        sa_setAudioConf.volumeGainDb = 0;
        mstts_setTtsApi.audioConfig = sa_setAudioConf;
    }
    private void setVoice(Voice srcVoice) {
        SetVoice sv_setVoiceConf = new SetVoice();
        switch(srcVoice) {
            case Voice.KR_FEMALE_A:
                sv_setVoiceConf.languageCode = "ko-KR";
                sv_setVoiceConf.name = "ko-KR-Wavenet-A";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            case Voice.KR_FEMALE_B:
                sv_setVoiceConf.languageCode = "ko-KR";
                sv_setVoiceConf.name = "ko-KR-Wavenet-B";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            case Voice.EN_FEMALE_A:
                sv_setVoiceConf.languageCode = "en-US";
                sv_setVoiceConf.name = "en-US-Wavenet-C";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            case Voice.EN_FEMALE_B:
                sv_setVoiceConf.languageCode = "en-US";
                sv_setVoiceConf.name = "en-US-Wavenet-E";
                sv_setVoiceConf.ssmlGender = "FEMALE";
                break;
            case Voice.KR_MALE_A:
                sv_setVoiceConf.languageCode = "ko-KR";
                sv_setVoiceConf.name = "ko-KR-Wavenet-C";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            case Voice.KR_MALE_B:
                sv_setVoiceConf.languageCode = "ko-KR";
                sv_setVoiceConf.name = "ko-KR-Wavenet-D";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            case Voice.EN_MALE_A:
                sv_setVoiceConf.languageCode = "en-US";
                sv_setVoiceConf.name = "en-US-Wavenet-A";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;
            case Voice.EN_MALE_B:
                sv_setVoiceConf.languageCode = "en-US";
                sv_setVoiceConf.name = "ken-US-Wavenet-B";
                sv_setVoiceConf.ssmlGender = "MALE";
                break;   
        }
        
        mstts_setTtsApi.voice = sv_setVoiceConf;
    }
}