/*
  * - Name : IntroManager.cs
  * - Writer : 이윤교
  * - Content : 게임 Intro 화면 구성
  * 
  *            -작성 기록-
  *            2021-07-19 : 제작 완료
  *
  *  IEnumerator DelayTime(float time) : 특정 시간 뒤에 함수 호출하기
  *         -> StartCoroutine(DelayTime(4)); : IEnumerator 인터페이스를 사용하는 메소드를 실행하기 위해 특정 호출 메소드 이용
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject g_StartPanel; //게임시작화면
    public GameObject g_IntroPanel; //회사로고화면
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayTime(4)); //4초 후 실행
    }

    IEnumerator DelayTime(float time)
    {
        yield return new WaitForSeconds(time);
        g_IntroPanel.SetActive(false); //인트로화면 페이드 아웃
        g_StartPanel.SetActive(true); //게임시작화면 페이드 인
    }

    public void GoStartSelectScene()
    {
        SceneManager.LoadScene("select_stage_scene"); //Start 버튼을 누르면 스테이지 선택 화면으로 넘어감
    }
}
