using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class attachStartScene : MonoBehaviour
{

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FirstLoad() {
        if (SceneManager.GetActiveScene().name.CompareTo("start_stage_scene") != 0) {
            SceneManager.LoadScene("start_stage_scene");
        }
    }
}
