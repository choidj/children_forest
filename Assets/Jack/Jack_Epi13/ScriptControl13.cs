using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptControl13 : MonoBehaviour
{
    /*싱글톤 구현*/

    //  여러 곳에서 동일한 인스턴스에 대해 공유할 수 있도록 static으로 선언
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

    void Start() //초기설정
    {
        //  Jack_Script 창에 스크립트를 보여줄 예정
        mg_setGameObject = GameObject.Find("Jack_Script"); 
        // mg_setGameObject오브젝트의 Text 컴포넌트를 담는 mt_setText
        mt_setText = mg_setGameObject.GetComponent<Text>(); 
        mt_setText.text = ms_setScriptText[mn_checkCurrentScr];
    }

    public void setNextScript() { //다음 문장 보여줌
        mn_checkCurrentScr++;
        mt_setText.text = ms_setScriptText[mn_checkCurrentScr];
    }
}
