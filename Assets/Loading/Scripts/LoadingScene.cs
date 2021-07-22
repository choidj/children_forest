using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public static string ms_moveNextScene;
    private AsyncOperation async_operation;

    private void Start()
    {
       StartCoroutine(LoadScene());
    }

    public static void v_loadScene(string sloadSceneName)
    {
        ms_moveNextScene = sloadSceneName;
        SceneManager.LoadScene("loading_scene");
    }
    IEnumerator LoadScene()
    {
        // next scene index
        async_operation = SceneManager.LoadSceneAsync(ms_moveNextScene);
        async_operation.allowSceneActivation = false;
        yield return new WaitForSeconds(1f);
        while (!async_operation.isDone)
        {
            if (async_operation.progress == .9f)
            {
                async_operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
