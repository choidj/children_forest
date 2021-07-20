using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTTS : MonoBehaviour
{
    VoiceManager vm;

    // Start is called before the first frame update
    void Start()
    {
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        vm.playVoice(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
