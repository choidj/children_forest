using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject IntroPanel;
    public GameObject StartPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayTime(3));
    }

    IEnumerator DelayTime(float time)
    {
        yield return new WaitForSeconds(time);

        IntroPanel.SetActive(false);
        StartPanel.SetActive(true);
    }

    public void StartStageScene()
    {
        SceneManager.LoadScene(2);
    }
}
