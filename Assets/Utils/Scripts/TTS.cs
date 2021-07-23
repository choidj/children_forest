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
*            2021-07-22 : createAudio() 함수의 반환 값을 AudioClip이 아닌 float Array 방식으로 바꾸었다.
 * 
 * - TTS Member Variable 
 * ms_useApiURL : Google TTS API 서버와 통신을 위한 URL 주소이다.
 * mstts_setTtsApi : Google TTS API 서버와 통신하여 데이터를 주고 받기 위한 데이터 형식을 맞춰주는 클래스이다. 이 안에는 보이스의 종류, 음조, 음성으로 바꿀 텍스트 등 음서으로 바꾸기 위해서 필요로 하는 세팅 데이터가 설정된다. 이때 이 세팅을 저장하는 이너클래스가 존재하는데, 각각 SetTextToSpeech, 
 * instance : 이 함수는 아무래도 통신을 하는 클래스로써, 무겁다고 작성자가 판단이 되어 클래스의 인스턴스를 계속 생산하는 것이 아니라, 싱글톤 디자인 패턴을 이용하여 하나의 인스턴스만 생성하게 만들었다. 이렇게 하면, 클래스의 인스턴스를 하나만 생성하여 여러 오브젝트 클래스들이 재사용할 수 있게 된다.
 * 
 * - TTS Member Function
 * TextToSpeechPost() : 본 스크립트 코드의 클래스에서는 Rest API를 이용하여 Google TTS API와 통신하기 때문에 그에 필요한 통신 코드가 들어있는 함수이다.
 * ConvertByteToFloat() : 통신을 통해 원하는 음성을 바이트 형태로 Google TTS API 서버에서 보내주게 되고, 우리는 그것을 AudioClip형태로 만들기 위해서 float형태로 변환시켜야 한다. 그 작업을 해주는 함수이다.
 * setInput() : 통신에 필요한 음성 세팅 정보에 대해서 설정하는 함수이다. 여기서 설정하는 정보는 어떤 Text를 음성으로 변환할지를 설정해주는 함수이다.
 * setAudioConfig() : 통신에 필요한 음성 세팅 정보에 대해서 설정하는 함수이다. 여기서 설정하는 정보는 음성의 음조, 말 빠르기를 어떻게 할지를 설정해주는 함수이다.
 * setVoice() : 통신에 필요한 음성 세팅 정보에 대해서 설정하는 함수이다. 여기서 설정하는 정보는 Google TTS API에서 정해놓은 보이스 종류를 설정해주는 함수이다.
 * CreateAudio() : 최종적으로 Google TTS API서버에서 받은 바이트 데이터를 float 데이터로 변환했었는데, 이것을 이용해서 유니티에서 이용할 수 있는 AudioClip으로 만드는 작업을 해주는 함수이다. -> 2021-07-20
 * 반환값을 AudioClip에서 float array 형태로 바꾸었다. 이 이유는, AudioClip을 다루려면, 메인 스레드가 다루어야 하기 때문이다. 
 * TTS 통신은 메인 스레드가 아닌 스레드에서 담당하도록 설계를 바꾸게 되었다. 그 이유는 메인 스레드에서 UI와 이 TTS 통신에 데이터 처리까지 맡게 되면, 부하가 커져서 화면이 멈추는 프리징 현상이 일어나게 되기 때문에 반환값을 바꾸어 메인 스레드가 아닌 스레드에서 처리하도록 바꾸었다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System;

//Google TTS API에서 세팅값으로 준 보이스 설정을 쓰기 편하게 enum형식으로 정리하였다. 이렇게 정의해놓으면, 유니티 인스펙터창에서 고를수 있어 편하다.
public enum Voice {
    KR_FEMALE_A,
    KR_FEMALE_B,
    KR_MALE_A,
    KR_MALE_B,
    EN_FEMALE_A,
    EN_FEMALE_B,
    EN_MALE_A,
    EN_MALE_B
}

// TTS 클래스이다. Google TTS API서버와 통신하여 최종적으로 createAudio()함수를 통해서 AudioClip 클래스를 반환하게 된다.
public class TTS {
    // 최종적으로 API서버와 통신하기 위한 데이터 형식을 정의하는 클래스이다. 안에도 클래스 형태로 있어서, 이를 Json형태로 변환하여 API서버가 원하는 형태로 요청을 보내게 된다.
    [System.Serializable]
    public class SetTextToSpeech {
        public SetInput input;
        public SetVoice voice;
        public SetAudioConfig audioConfig;
    }
    // 음성으로 바꿀 텍스트 데이터를 넣는 클래스로, 최종적으로 SetTextToSpeech클래스안에 들어가게 된다.
    [System.Serializable]
    public class SetInput {
        public string text;
    }

    // 음성의 커스텀 세팅 설정 데이터를 넣는 클래스로, 최종적으로 SetTextToSpeech클래스안에 들어가게 된다.
    [System.Serializable]
    public class SetVoice {
        public string languageCode;
        public string name;
        public string ssmlGender;
    }

    // 음성의 커스텀 세팅 설정 데이터를 넣는 클래스로, 최종적으로 SetTextToSpeech클래스안에 들어가게 된다.
    [System.Serializable]
    public class SetAudioConfig {
        public string audioEncoding;
        public float speakingRate;
        public float pitch;
        public int volumeGainDb;
    }

    // API 서버에서 요청에 대한 응답을 받는 클래스로, 스트링(바이트) 형태로 받게 된다. 이를 float 형태로 변환하고 우리가 원하는 형태인 AudioClip으로 변환하게 된다.
    [System.Serializable]
    public class GetContent {
        public string audioContent;
    }

    private string ms_useApiURL = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=AIzaSyANPEwOXAhoxpeYwpJQBUkZRew42sI9ECU";
    private SetTextToSpeech mstts_setTtsApi;
    private static TTS instance = null;

    // TTS의 생성자이다.
    public TTS() {
        mstts_setTtsApi = new SetTextToSpeech();
    } 

    // TTS는 싱글톤 디자인 패턴을 이용할 거므로, 앞으로 이 정적 함수를 통해 TTS 클래스의 인스턴스를 가져온다.
    public static TTS GetInstance() {
        // 만약 instance가 존재하지 않을 경우 새로 생성한다.
        if (instance is null) {
            instance = new TTS();
        }
        // instance를 반환한다.
        return instance;
    }
    //convert the received byte array to float array. And then, return float array..
    public float[] CreateAudio(string sTargetSpeech, Voice vTargetVoice, float fSetPitch = 0f, float fSpeakRate = 0.6f) {

        setAudioConfig(fSetPitch, fSpeakRate);
        setVoice(vTargetVoice);
        setInput(sTargetSpeech);

        //After request HttpWebRequest, save the returned data in string format.
        var s_str = TextToSpeechPost(mstts_setTtsApi);
        
        GetContent gc_Info = JsonUtility.FromJson<GetContent>(s_str);

        var ba_convertByteArray = Convert.FromBase64String(gc_Info.audioContent);
        var fa_convertFloatArray = ConvertByteToFloat(ba_convertByteArray);

        return fa_convertFloatArray;
    }
    
    // 스트링형태로 받은 응답 데이터를 우리가 원하는 float형태로 만들어 준다.
    private static float[] ConvertByteToFloat(byte[] baArray) {
        float[] fa_tempFloatArr = new float[baArray.Length / 2];

        for(int i = 0; i < fa_tempFloatArr.Length; i++) {
            fa_tempFloatArr[i] = BitConverter.ToInt16(baArray, i*2) / 32768.0f;
        }
        return fa_tempFloatArr;
    }
    
    // REST API를 통해 Google TTS API서버와 통신하는 코드이다.
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
    // 이 아래 코드는 클래스 앞부분에서 보았던 음성 세팅 설정들을 설정해주는 함수이다.
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