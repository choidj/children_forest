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
        SceneManager.LoadScene("load_scene");
    }
    IEnumerator LoadScene()
    {
        async_operation = SceneManager.LoadSceneAsync(ms_moveNextScene);
        async_operation.allowSceneActivation = false;

        float timer = 0f;
        while (!async_operation.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (async_operation.progress >= 0.9f)
                async_operation.allowSceneActivation = true;
        }
    }
}
