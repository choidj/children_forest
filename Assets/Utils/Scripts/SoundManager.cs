using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Sound {
    public string name;
    public AudioClip sound;
}   
public class SoundManager : MonoBehaviour
{

    public Sound[] mssl_saveSounds;
    private AudioSource mas_outputSounds;
    void Start() {
        mas_outputSounds = this.GetComponent<AudioSource>();
    }
    public void playSound(int id) {
        mas_outputSounds.PlayOneShot(mssl_saveSounds[id].sound);
    }
    public void playSound(string soundName) {
        for(int i = 0; i < mssl_saveSounds.Length; i++) {
            if(mssl_saveSounds[i].name == soundName)
                mas_outputSounds.PlayOneShot(mssl_saveSounds[i].sound);
        }
    }
}
