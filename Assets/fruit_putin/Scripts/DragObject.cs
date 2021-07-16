using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {
    private TTS mtts_tellFruitName;
    private AudioSource mas_playFruitNameVoice;
    private bool mb_checkClickOnce = false;
    void Start() {
        mtts_tellFruitName = TTS.GetInstance(Voice.KR_FEMALE_A);
        mas_playFruitNameVoice = gameObject.GetComponent<AudioSource>();
    }
    private void OnMouseDrag() {
        if(!mb_checkClickOnce) {
            mtts_tellFruitName.CreateAudio("사과", mas_playFruitNameVoice);
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
}