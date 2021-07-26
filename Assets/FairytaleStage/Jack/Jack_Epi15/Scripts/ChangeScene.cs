using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void ReStart(){
        SceneManager.LoadScene("Jack_Epi1");
    }

    public void Select(){
        SceneManager.LoadScene("select_stage_scene");
        var obj = GameObject.Find("BGMmanager");
        if(obj != null) {
            Destroy(obj);
        }
    }
}
