using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutFruits_collideFruitAndBasket : MonoBehaviour {
    private VoiceManager mvm_voiceManager;
    private int mn_fruitId;
    void Start() {
        mvm_voiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>() as VoiceManager;
        Debug.Log(mvm_voiceManager);
        mn_fruitId = gameObject.GetComponent<ControlFruit>().mn_fruitId;
    }
    void OnTriggerEnter2D(Collider2D cCollideObject) {
        if (cCollideObject.tag == "PutFruitInBasket")
        {
            mvm_voiceManager.playVoice(mn_fruitId+1); //영어
            Destroy(this.gameObject);
        }
    }
}
