using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HarpJackCollision: MonoBehaviour
{
    public GameObject mg_talk_Prefab;


    void OnTriggerEnter2D(Collider2D cCollideObject)
    {
        GameObject g_talk = Instantiate(mg_talk_Prefab) as GameObject;
        Invoke("changeNextScene", 3f);
    }
    void changeNextScene() {
        SceneManager.LoadScene("Jack_Epi13");
    }
}
