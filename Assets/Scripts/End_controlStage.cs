using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_controlStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Invoke("v_changeSelectStage", 3f);
    }

    void v_changeSelectStage() {
        SceneManager.LoadScene("select_stage_scene");
    }
}
