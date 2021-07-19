using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFruit : MonoBehaviour {
    private VoiceManager mvm_voiceManager;
    public int mn_fruitId;
    private Vector2 mv2_remembPos;
    private bool mb_checkClickOnce = false;
    void Start() {
        mvm_voiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>() as VoiceManager;
        mv2_remembPos = gameObject.transform.position;

    }
    void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv2_remembPos, 2f * Time.deltaTime);
    }
    private void OnMouseDrag() {
        if(!mb_checkClickOnce) {
            mvm_voiceManager.playVoice(mn_fruitId); //한국 보이스 출력
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