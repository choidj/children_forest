using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutFruits_collideFruitAndBasket : MonoBehaviour {
    private VoiceManager mvm_voiceManager;
    private int mn_fruitId;
    // When the fruit collide basket, fruit will be disappeared.
    private bool mb_checkClickOnce = false;
    void Start() {
        mvm_voiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>() as VoiceManager;
        Debug.Log(mvm_voiceManager);
        mn_fruitId = gameObject.GetComponent<DragObject>().mn_fruitId;
    }
    void OnTriggerEnter2D(Collider2D cCollideObject) {
        if (cCollideObject.tag == "PutFruitInBasket")
        {
            FRUIT_TYPE fType = (FRUIT_TYPE)(mn_fruitId + 1);
            mvm_voiceManager.playVoice(fType); //영어
            Destroy(this.gameObject);
        }
    }
}
