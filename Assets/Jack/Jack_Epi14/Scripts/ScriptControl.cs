using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptControl : MonoBehaviour
{
    private static ScriptControl instance;
    public static ScriptControl GetInstance() {
        // 만약 instance가 존재하지 않을 경우
        if (!instance)
        {
            // ScriptControl 클래스의 instance를 찾는다
            instance = GameObject.FindObjectOfType(typeof(ScriptControl)) as ScriptControl;
            if (!instance)
            {
                // 찾아봐도 존재하지 않을 경우 새로 만든다
                GameObject obj = new GameObject("ScriptControl"); // 이름인 ScriptControl인 오브젝트 생성
                instance = obj.AddComponent(typeof(ScriptControl)) as ScriptControl;
            }
        }
        // instance를 반환한다.
        return instance;
    }
    public const int mn_setScriptNum = 5;
    public string[] ms_setScriptText = new string[mn_setScriptNum];
    private int mn_checkCurrentScr = 0;
    private Text mt_setText;
    private GameObject mg_setGameObject;
    // Start is called before the first frame update
    void Start()
    {
        mg_setGameObject = GameObject.Find("Jack_Script");
        mt_setText = mg_setGameObject.GetComponent<Text>();
        mt_setText.text = ms_setScriptText[mn_checkCurrentScr];
    }

    // Update is called once per frame
    public void setNextScript() {
        mn_checkCurrentScr++;
        mt_setText.text = ms_setScriptText[mn_checkCurrentScr];
    }
}