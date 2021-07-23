using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private AudioSource audioSource;
    //public bool fadeOut;
    // fade out 시간 설정 1s
    public double fadeOutSeconds = 1.0;
    bool isFadeOut = true;
    double fadeDeltaTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeOut)
        {
            fadeDeltaTime += Time.deltaTime;
            if(fadeDeltaTime >= fadeOutSeconds)
            {
                fadeDeltaTime = fadeOutSeconds;
                isFadeOut = false;
            }
            audioSource.volume = (float)(1.0 - (fadeDeltaTime / fadeOutSeconds));
        }
    }
}
