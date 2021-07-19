using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FixedStartScene : MonoBehaviour {

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    static void FirstLoad()
    {
        if (SceneManager.GetActiveScene().name.CompareTo("intro") != 0){
            SceneManager.LoadScene("intro");
        }
    }

}
