/*
 * - Name : Jack3_MainScript.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 잭과콩나무 에피소드3 - Main 스크립트(대사) 관리 스크립트
 * 
 * - Update Log -
 * 2021-07-13 : 제작 완료
 * 2021-07-23 : 주석 변경
 * 
 * - 사용법
 * 1. ms_ScriptText 에 문장들을 입력한다.
 * 2. 구분자는 @로 해두었으니 구분자를 추가해준다.
 * 3. 로그를 통해 제대로 나뉘었는지 확인한다.
 * 4. v_NextScript()를 통해 다음 스크립트를 출력할수 있다.
 * 5. v_NoneScript()를 통해 스크립트내용을 공백으로 설정할수 있다.
 *                    
 * - Variable 
 * mg_MainScript                    스크립트를 보여주는 메인 스크립트 오브젝트
 * ms_ScriptText                    스크립트를 통으로 넣어주는 스트링
 * msa_SplitText[]                  구분자를 기준으로 여기에 나눠서 저장된다.
 * n_i                              for문용 변수
 * mn_Sequence                      스크립트 읽을 순서 변수
 * 
 * 
 * - Function
 * v_NoneScript()                   스크립트를 공백으로 설정해준다.
 * v_NextScript()                   다음 스크립트를 입력한다.
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jack3_MainScript : MonoBehaviour{
    GameObject mg_MainScript;                                                                   // 연결할 스크립트 오브젝트 선언

    // ms_ScriptText 에 문장을 입력해주세요.
    private string ms_ScriptText = "잭은 길을 가다가 할아버지를 만났어요.@잭은 마술 콩이라는 말에 솔깃해졌어요.@잭은 냉큼 커다란 젖소와 콩을 바꾸었어요.";
    private string[] msa_SplitText;
    private int mn_Sequence;

    void Start(){
        this.mg_MainScript = GameObject.Find("Jack3_Script");                                   // 스크립트 오브젝트 연결

        // 문자열을 구분자를 기준으로 나누고 제대로 나뉘었는지 확인한다.
        msa_SplitText = ms_ScriptText.Split('@');                                               // 구분자를 수정할려면 이 부분을 수정
        for (int n_i = 0; n_i < msa_SplitText.Length; n_i++){
            Debug.Log("메인 스크립트[" + n_i + "] : " + msa_SplitText[n_i]);
        }
        mn_Sequence = -1;
    }

    #region 함수 선언부

    /// <summary>
    /// 스크립트 관련 함수
    /// </summary>
    public void v_NoneScript(){
        this.mg_MainScript.GetComponent<Text>().text = "";
    }
    //다음 스크립트를 보여준다.
    public void v_NextScript(){
        mn_Sequence += 1;
        if (mn_Sequence < msa_SplitText.Length){
            this.mg_MainScript.GetComponent<Text>().text = msa_SplitText[mn_Sequence];
        }
        else if(mn_Sequence >= msa_SplitText.Length){
            Debug.Log("메인 스크립트 현재순서 : " + mn_Sequence);
            Debug.Log("메인 스크립트 최대 값 : " + msa_SplitText.Length);
            Debug.Log("메인 스크립트 크기 초과");
        }
    }
    #endregion
}
