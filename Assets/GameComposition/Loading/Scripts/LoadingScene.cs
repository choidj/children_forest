/*
 * - Name : LoadingScene.cs
 * - Writer : 최대준
 * - Content : 로딩 씬으로, 로딩 씬이 보여질 동안, 다음 씬을 로드하고 준비한다.
 *          -기록-
 *          2021-07-19 : 코드 구현
 *          2021-07-21 : 주석 작성
 * - LoadingScene Member variable
 * string ms_moveNextScene : 다음 씬의 이름을 저장하고 있는 변수이다.
 * AsyncOperation async_operation : 다음 씬의 로드 및 진행 상황을 확인 할 수 있는 클래스 변수이다.
 * - LoadingScene Member function
 * Start() : 드래그 시에 잭에게 띄워놓았던 말풍선을 없애는 함수이다.
 * v_loadScene : 멤버 변수로 다음 씬의 이름을 저장하고, 로딩 씬을 현재 화면에 띄우는 함수이다.
 * LoadScene() : 로딩 씬을 띄우고 있는 동안, 다음 씬의 초기화, 로드 등을 진행하도록 호출하는 함수이다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// loading Scene을 컨트롤하며, 다음 씬의 로드, 진행상황을 확인하여 준비가 다 되었을 때, 다음 씬으로 전환하도록 한다.
public class LoadingScene : MonoBehaviour
{
    public static string ms_moveNextScene;
    private AsyncOperation async_operation;

    // 메인 스레드는 UI를 담당하므로 여기서 로드 해버리면 화면이 멈추는 프리징현상이 일어날 수 있기 때문에 코루틴을 이용하여 메인 스레드가 아닌 스레드가 다음 씬의 로드를 담당하도록 한다.
    private void Start()
    {
       StartCoroutine(LoadScene());
    }
    // 스태틱 함수로, 이 로딩씬을 인스턴스로 초기화가 필요없이 이 함수를 바로 호출하면, 로딩씬이 켜지도록 하는 함수이다. 또한 다음 씬의 이름을 클래스 변수에 저장한다. (스태틱 함수이므로 똑같은 스태틱 변수에 저장해야 한다.)
    public static void v_loadScene(string sloadSceneName)
    {
        ms_moveNextScene = sloadSceneName;
        SceneManager.LoadScene("load_scene");
    }
    // 코루틴을 이용하여 비동기적으로 다음 씬을 로드한다.
    IEnumerator LoadScene()
    {
        async_operation = SceneManager.LoadSceneAsync(ms_moveNextScene);
        async_operation.allowSceneActivation = false;

        float timer = 0f;
        while (!async_operation.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (async_operation.progress >= 0.9f) {
                if(timer >= 1.5f) 
                    async_operation.allowSceneActivation = true;
                
            }
        }
    }
}
