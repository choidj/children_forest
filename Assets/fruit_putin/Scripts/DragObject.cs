using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {
    private AudioSource mas_playFruitNameVoice;
    private AudioClip mac_saveAudioClip;
    private bool mb_checkClickOnce = false;
    void Start() {
        mas_playFruitNameVoice = gameObject.GetComponent<AudioSource>();
    }
    private void OnMouseDrag() {
        if(!mb_checkClickOnce) {
            mas_playFruitNameVoice.PlayOneShot(mac_saveAudioClip);
            mb_checkClickOnce = true;
        }
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }
    public void setAudioClip(AudioClip acSrcAudioClip) {
        mac_saveAudioClip = acSrcAudioClip;
    }
    void OnMouseUp() {
        mb_checkClickOnce = false;
    }
}