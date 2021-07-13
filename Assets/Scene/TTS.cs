using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using System.Text;

/*
문제를 읽어준다
1. 문제 텍스트를 구글tts한테 http로 보내서 음성 파일로 만든다
2. 음성 파일을 AudioSource로 불러와서 출력한다
*/
public class TTS : MonoBehaviour
{
    public AudioSource textAudio;
    public string testText;
    void Start() {
        read(testText);
    }
    public string apiURL = "https://texttospeech.googleapis.com/v1/text:synthesize?&key=6960ad498d221baa1a254190fad3c6ae57db563a";
    public void read(string text)
    {
        try
        {
            string webAddr = apiURL;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{ \"audioConfig\": {\"audioEncoding\": \"LINEAR16\",\"pitch\": 0,\"speakingRate\": 1},\"input\": {\"text\": \"<REPLACE_TEXT>\"},\"voice\": {\"languageCode\": \"ko-KR\",\"name\": \"ko-KR-Standard-A\"}}\" \"https://texttospeech.googleapis.com/v1/text:synthesize?&key=6960ad498d221baa1a254190fad3c6ae57db563a \">audio_text.txt";

                json = json.Replace("<REPLACE_TEXT>", testText);
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                Debug.Log("Response:" + responseText);
                byte[] byte64 = Convert.FromBase64String(responseText);
                string base64Decoded = Encoding.UTF8.GetString(byte64);

                byte[] buf = Encoding.UTF8.GetBytes(base64Decoded);

                float[] f = ConvertByteToFloat(buf);

                AudioClip audioClip = AudioClip.Create("testSound", f.Length, 1, 44100, false);
                audioClip.SetData(f, 0);

                textAudio.clip = audioClip;

                textAudio.Play();
   
            }
        }
        catch (WebException ex)
        {
            print(ex.Message);
        }
    }

    private float[] ConvertByteToFloat(byte[] array)
    {
        float[] floatArr = new float[array.Length / 4];
        for (int i = 0; i < floatArr.Length; i++)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array, i * 4, 4);
            floatArr[i] = BitConverter.ToSingle(array, i * 4) / 0x80000000;
        }
        return floatArr;
    }
}