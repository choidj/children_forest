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
        public int pitch;
        public int volumeGainDb;
    }

    [System.Serializable]
    public class GetContent {
        public string audioContent;
    }

    private string ms_useApiURL = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=AIzaSyANPEwOXAhoxpeYwpJQBUkZRew42sI9ECU";
    private SetTextToSpeech tts;
    //constructor initialize these class..
    //initialize the json object config to send a google tts api.
    public TTS()
    {
        tts = new SetTextToSpeech();
        setVoice(Voice.KR_FEMALE_A);

        SetAudioConfig sa_setAudioConf = new SetAudioConfig();
        sa_setAudioConf.audioEncoding = "LINEAR16";
        sa_setAudioConf.speakingRate = 0.8f;
        sa_setAudioConf.pitch = 0;
        sa_setAudioConf.volumeGainDb = 0;
        tts.audioConfig = sa_setAudioConf;
    }
    public TTS(Voice gender)
    {
        tts = new SetTextToSpeech();

        setVoice(gender);

        SetAudioConfig sa_setAudioConf = new SetAudioConfig();
        sa_setAudioConf.audioEncoding = "LINEAR16";
        sa_setAudioConf.speakingRate = 0.8f;
        sa_setAudioConf.pitch = 0;
        sa_setAudioConf.volumeGainDb = 0;
        tts.audioConfig = sa_setAudioConf;
    }    
    private static TTS instance = null;
    public static TTS GetInstance(Voice gender)
    {
        // 만약 instance가 존재하지 않을 경우 새로 생성한다.
        if (instance is null)
        {
            instance = new TTS(gender);
        }
        else
            instance.setVoice(gender);
        // instance를 반환한다.
        return instance;
    }
    //convert the received byte array to float array...
    public void CreateAudio(string speech, AudioSource asPlayAudioSource) {
        SetInput si_setInputData = new SetInput();
        si_setInputData.text = speech;
        tts.input = si_setInputData;

        //After request HttpWebRequest, save the returned data in string format.
        var s_str = TextToSpeechPost(tts);
        
        GetContent gc_Info = JsonUtility.FromJson<GetContent>(s_str);

        var ba_convertByteArray = Convert.FromBase64String(gc_Info.audioContent);
        var fa_convertFloatArray = ConvertByteToFloat(ba_convertByteArray);

        AudioClip ac_createAudioClip = AudioClip.Create("audioContent", fa_convertFloatArray.Length, 1, 44100, false);
        ac_createAudioClip.SetData(fa_convertFloatArray, 0);

        asPlayAudioSource.PlayOneShot(ac_createAudioClip);
    }
    
    private static float[] ConvertByteToFloat(byte[] baArray) {
        float[] fa_tempFloatArr = new float[baArray.Length / 2];

        for(int i = 0; i < fa_tempFloatArr.Length; i++) {
            fa_tempFloatArr[i] = BitConverter.ToInt16(baArray, i*2) / 32768.0f;
        }
        return fa_tempFloatArr;
    }
    
    public string TextToSpeechPost(object oSendData) {
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
    void setVoice(Voice srcVoice) {
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
        
        tts.voice = sv_setVoiceConf;
    }
}