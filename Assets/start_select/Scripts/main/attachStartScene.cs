using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class attachStartScene : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("start_stage_scene");
    }
}
