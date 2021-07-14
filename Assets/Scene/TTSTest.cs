using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTSTest : MonoBehaviour
{
    private TTS test;
    private AudioSource a;
    // Start is called before the first frame update
    void Start()
    {
        test = new TTS(Voice.KR_MALE_A);
        a = gameObject.GetComponent<AudioSource>();
        test.CreateAudio("하이 에이치 하이", a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
