using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {
    private VoiceManager mvm_voiceManager;
    public int mn_fruitId;
    private bool mb_checkClickOnce = false;
    void Start() {
        mvm_voiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>() as VoiceManager;
    }
    private void OnMouseDrag() {
        if(!mb_checkClickOnce) {
            FRUIT_TYPE fType = (FRUIT_TYPE)mn_fruitId;
            mvm_voiceManager.playVoice(fType); //한국 보이스 출력
            mb_checkClickOnce = true;
        }
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }
    void OnMouseUp() {
        mb_checkClickOnce = false;
    }
    public void setFruitId(int nId) {
        mn_fruitId = nId;
    }
}