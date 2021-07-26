using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    void Awake() {
        var obj = FindObjectsOfType<BGMmanager>();
        if(obj != null) {
            if (obj.Length == 1) {
            DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
            }
        }
    }
}
