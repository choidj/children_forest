/*
 * - Name : Jack3_GFScript.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 잭과콩나무 에피소드3 - 할아버지 스크립트(대사) 관리 스크립트
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

public class Jack3_GFScript : MonoBehaviour
{
    GameObject mg_GFScript;                                                                         // 연결할 스크립트 오브젝트 선언

    //ms_ScriptText 에 문장을 입력해주세요.
    private string ms_ScriptText = "얘야 어딜 그렇게 바쁘게 가니?@그럼 그 젖소와 이 콩을 바꾸자꾸나.@이 콩은 심은 지 하루 만에 하늘에 닿을 만큼 높이 자라는 마술 콩이란다.";
    private string[] msa_SplitText;
    private int mn_Sequence;

    void Start(){
        this.mg_GFScript = GameObject.Find("Jack3_GrandFatherScript");                              // 스크립트 오브젝트 연결

        //문자열을 구분자를 기준으로 나누고 제대로 나뉘었는지 확인한다.
        msa_SplitText = ms_ScriptText.Split('@');                                                   // 구분자를 수정할려면 이 부분을 수정
        for (int n_i = 0; n_i < msa_SplitText.Length; n_i++)
        {
            Debug.Log("할아버지 스크립트[" + n_i + "] : " + msa_SplitText[n_i]);
        }
        mn_Sequence = -1;
    }

    #region 함수 선언부

    /// <summary>
    /// 스크립트 관련 함수
    /// </summary>
    public void v_NoneScript(){                                                                     // 스크립트 내용을 공백으로 설정
        this.mg_GFScript.GetComponent<Text>().text = "";
    }
    public void v_NextScript(){                                                                     // 다음 스크립트를 입력한다.
        mn_Sequence += 1;
        if (mn_Sequence < msa_SplitText.Length){
            this.mg_GFScript.GetComponent<Text>().text = msa_SplitText[mn_Sequence];
        }
        else if (mn_Sequence >= msa_SplitText.Length){
            Debug.Log("할아버지 스크립트 현재순서 : " + mn_Sequence);
            Debug.Log("할아버지 스크립트 최대 값 : " + msa_SplitText.Length);
            Debug.Log("할아버지 스크립트 크기 초과");
        }
    }

    #endregion
}
