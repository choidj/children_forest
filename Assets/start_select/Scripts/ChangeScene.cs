using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static string ms_moveNextScene;

    //private void Start()
    //{
    //    StartCoroutine(LoadScene());
    //}

    public static void LoadScene(string sloadSceneName)
    {
        //ms_moveNextScene = s_loadSceneName;
        //SceneManager.LoadScene("LoadingScene");
        SceneManager.LoadScene(sloadSceneName);
    }

    //IEnumerator LoadScene()
    //{
    //    yield return null;
    //    AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
    //    op.allowSceneActivation = false;
    //    float timer = 0.0f;
    //    while (!op.isDone)
    //    {
    //        yield return null;
    //        timer += Time.deltaTime;
    //        if (op.progress < 0.9f)
    //        {
    //            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
    //            if (progressBar.fillAmount >= op.progress)
    //            {
    //                timer = 0f;
    //            }
    //        }
    //        else
    //        {
    //            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
    //            if (progressBar.fillAmount == 1.0f)
    //            {
    //                op.allowSceneActivation = true;
    //                yield break;
    //            }
    //        }
    //    }
    //}
}
