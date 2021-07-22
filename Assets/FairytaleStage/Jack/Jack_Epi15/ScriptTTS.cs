using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTTS : MonoBehaviour
{
    VoiceManager vm;
    bool mb_checkPlayOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vm.mb_checkSceneReady) {
            if(mb_checkPlayOnce) {
                vm.playVoice(0);
                mb_checkPlayOnce = false;
            }
        }
        
    }
}
