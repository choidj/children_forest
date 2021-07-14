using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System;

public class TTS : MonoBehaviour
{
    private string ms_useApiURL = "https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=AIzaSyANPEwOXAhoxpeYwpJQBUkZRew42sI9ECU";
    public AudioSource audioSource;
    private SetTextToSpeech tts = new SetTextToSpeech();
    //initialize the json object config to send a google tts api.
    void Init() {
        SetInput si_setInputData = new SetInput();
        si_setInputData.text = "테스트테스트원투";
        tts.input = si_setInputData;

        SetVoice sv_setVoiceConf = new SetVoice();
        sv_setVoiceConf.languageCode = "ko-KR";
        sv_setVoiceConf.name = "ko-KR-Wavenet-A";
        sv_setVoiceConf.ssmlGender = "FEMALE";
        tts.voice = sv_setVoiceConf;

        SetAudioConfig sa_setAudioConf = new SetAudioConfig();
        sa_setAudioConf.audioEncoding = "LINEAR16";
        sa_setAudioConf.speakingRate = 0.8f;
        sa_setAudioConf.pitch = 0;
        sa_setAudioConf.volumeGainDb = 0;
        tts.audioConfig = sa_setAudioConf;
    }

    //convert the received byte array to float array...
    private void CreateAudio() {
        //After request HttpWebRequest, save the returned data in string format.
        var s_str = TextToSpeechPost(tts);
        
        GetContent gc_Info = JsonUtility.FromJson<GetContent>(s_str);

        var ba_convertByteArray = Convert.FromBase64String(gc_Info.audioContent);
        var fa_convertFloatArray = ConvertByteToFloat(ba_convertByteArray);

        AudioClip ac_createAudioClip = AudioClip.Create("audioContent", fa_convertFloatArray.Length, 1, 44100, false);
        ac_createAudioClip.SetData(fa_convertFloatArray, 0);

        AudioSource as_playAudioSource = FindObjectOfType<AudioSource>();
        as_playAudioSource.PlayOneShot(ac_createAudioClip);
    }
    
    private static float[] ConvertByteToFloat(byte[] baArray) {
        float[] fa_tempFloatArr = new float[baArray.Length / 2];

        for(int i = 0; i < fa_tempFloatArr.Length; i++) {
            fa_tempFloatArr[i] = BitConverter.ToInt16(baArray, i*2) / 32768.0f;
        }
        return fa_tempFloatArr;
    }
    
    void Start() {
        Init();
        CreateAudio();
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
}



    





