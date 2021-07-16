using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScene : MonoBehaviour
{
    //잘보이나~~~
    public string ms_loadScene;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            clickedMouse();
        }
    }
    void clickedMouse() {
        SceneManager.LoadScene(ms_loadScene);
    }
}
