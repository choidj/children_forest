using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStageControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Invoke("nextStage", 2f);
    }

    void nextStage() {
        SceneManager.LoadScene("select_stage_scene");
    }
}
