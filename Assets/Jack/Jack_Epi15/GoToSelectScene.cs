using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSelectScene : MonoBehaviour
{
    public void SceneChange(){
        SceneManager.LoadScene("select_stage_scene");
    }
}
