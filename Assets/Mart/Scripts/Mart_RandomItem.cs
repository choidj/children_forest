/*
 * - Name : Mart_RandomItem.cs
 * - Writer : 김명현
 * 
 * - Content
 * Random selection of items, so that they are not duplicated
 * 
 * -Update Log-
 * 2021-07-07 : 작성 완료
 * 2021-07-08 : OX 기능 추가
 * 2021-07-09 : 변수명 정리
 * 2021-07-21 : 인코딩 형식 수정 및 주석 재작성
 *                  
 * - Variable 
 * mg_RandomItem : Mart_RandomItem 오브젝트 연결을 위한 변수
 * mg_GameDirector : GameDirector 오브젝트 연결을 위한 변수
 * mspa_SpriteImage : 아이템 오브젝트 이미지 저장
 * mn_RandomValue : 랜덤 아이템 값 저장해두는 변수
 * mn_leftTime : 남은 아이템 개수 저장해두는 변수
 * mb_ItemFlag : 정답이 바뀌어야되는 타이밍을 알려주는 flag
 * 
 * -Function()
 * n_n_ReturnAnswer() : 랜덤 아이템 정답 값을 반환해주는 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mart_RandomItem : MonoBehaviour{

    GameObject mg_RandomItem;                                                                               // Mart_RandomItem 오브젝트 연결을 위한 변수
    GameObject mg_GameDirector;                                                                             // GameDirector 오브젝트 연결을 위한 변수
    public Sprite[] mspa_SpriteImage = new Sprite[6];                                                       // 아이템 오브젝트 이미지 저장
    int mn_RandomValue;                                                                                     // 랜덤 아이템 값 저장해두는 변수
    int mn_leftTime;                                                                                        // 남은 아이템 개수 저장해두는 변수
    bool mb_ItemFlag;                                                                                       // 정답이 바뀌어야되는 타이밍을 알려주는 flag

    void Start(){
        this.mg_GameDirector = GameObject.Find("GameDirector");                                             // 오브젝트 연결
        this.mg_RandomItem = GameObject.Find("Mart_RandomItem");
        mn_RandomValue = mg_GameDirector.GetComponent<Mart_ControlUI>().n_MartRandomItemValue();            // 랜덤 값 저장
        this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue];        // 해당 랜덤 값에 맞는 아이템 이미지 변경
        mb_ItemFlag = false;                                                                                // Flag 값 False 로 초기화
    }

    void Update(){
        mb_ItemFlag = mg_GameDirector.GetComponent<Mart_ControlUI>().b_checkFlag();                         // 정답이 바뀌는 Flag값 실시간 업데이트
        if (mb_ItemFlag == true){                                                                           // Flag값이 바뀐경우
            mn_leftTime = mg_GameDirector.GetComponent<Mart_ControlUI>().n_HowManyleftArr();                // 남은 아이템 개수 확인
            if(mn_leftTime != 0){                                                                           // 아직 아이템이 남았다면
                mn_RandomValue = mg_GameDirector.GetComponent<Mart_ControlUI>().n_MartRandomItemValue();    // 랜덤값 재할당
                this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue];// 랜덤값에 맞게 아이템 이미지 변경
                mg_GameDirector.GetComponent<Mart_ControlUI>().v_ChangeFlagFalse();                         // Flag값 False로 변경
            }
            else if(mn_leftTime == 0){                                                                      // 만약 남은 아이템개수가 0개라면 Clear                            
                SceneManager.LoadScene("end_scene");
            } 
        }
    }
    /// <summary>
    /// 랜덤 아이템 정답 값을 반환해주는 함수
    /// </summary>
    /// <returns>int 정답 값</returns>
    public int n_ReturnAnswer(){                                                            
        return mn_RandomValue;
    }
}
