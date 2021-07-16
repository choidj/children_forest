/*
 * - Name : Jack4_MotherScript.cs
 * - Writer : 김명현
 * - Content : 잭과콩나무 에피소드3 - 어머니 스크립트(대사) 관리 스크립트
 * 
 *             -사용법-
 *            1. ms_ScriptText 에 문장들을 입력한다.
 *            2. 구분자는 @로 해두었으니 구분자를 추가해준다.
 *            3. 로그를 통해 제대로 나뉘었는지 확인한다.
 *            4. v_NextScript()를 통해 다음 스크립트를 출력할수 있다.
 *            5. v_NoneScript()를 통해 스크립트내용을 공백으로 설정할수 있다.
 *            
 *            
 *            
 *            
 *            
 *            -작성 기록-
 *            2021-07-14 : 제작 완료
 *            
 *            
 *            
 *            
 * 
 * -Variable 
 * mg_MotherScript : 스크립트를 보여주는 오브젝트
 * ms_ScriptText : 스크립트를 통으로 넣어주는 스트링
 * msa_SplitText[] : 구분자를 기준으로 여기에 나눠서 저장된다.
 * n_i : for문용 변수
 * mn_Sequence : 스크립트 읽을 순서 변수
 * 
 * 
 * -Function
 * v_NoneScript() : 스크립트를 공백으로 설정해준다.
 * v_NextScript() : 다음 스크립트를 보여준다.
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jack4_MotherScript : MonoBehaviour
{
    GameObject mg_MotherScript;   //연결할 스크립트 오브젝트 선언

    //ms_ScriptText 에 문장을 입력해주세요.
    private string ms_ScriptText = "잭, 벌써 다녀왔니?@뭐라고? 젖소를 겨우 콩 한알과 바꾸었다는 거니?";
    private string[] msa_SplitText;
    private int mn_Sequence;



    // Start is called before the first frame update
    void Start()
    {
        this.mg_MotherScript = GameObject.Find("MotherScript");   //스크립트 오브젝트 연결

        //문자열을 구분자를 기준으로 나누고 제대로 나뉘었는지 확인한다.
        msa_SplitText = ms_ScriptText.Split('@');   //구분자를 수정할려면 이 부분을 수정
        for (int n_i = 0; n_i < msa_SplitText.Length; n_i++)
        {
            Debug.Log("어머니 스크립트[" + n_i + "] : " + msa_SplitText[n_i]);
        }
        mn_Sequence = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //스크립트내용을 공백으로 설정해줌
    public void v_NoneScript()
    {
        this.mg_MotherScript.GetComponent<Text>().text = "";
    }

    //다음 스크립트를 보여준다.
    public void v_NextScript()
    {
        mn_Sequence += 1;
        if (mn_Sequence < msa_SplitText.Length)
        {
            this.mg_MotherScript.GetComponent<Text>().text = msa_SplitText[mn_Sequence];
        }
        else if (mn_Sequence >= msa_SplitText.Length)
        {
            Debug.Log("어머니 스크립트 현재순서 : " + mn_Sequence);
            Debug.Log("어머니 스크립트 최대 값 : " + msa_SplitText.Length);
            Debug.Log("어머니 스크립트 크기 초과");
        }
    }
}
