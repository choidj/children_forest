using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_controlStage : MonoBehaviour
{
    void Start() {
        Invoke("v_changeSelectStage", 4f);
    }

    void v_changeSelectStage() {
        SceneManager.LoadScene("select_stage_scene");
    }
}
