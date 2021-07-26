/*
  * - Name : CollideBeanStalk.cs
  * - Writer : 이윤교
  * - Content : 잭과콩나무 에피소드14 - 콩나무 도끼질 하며 자르기 스크립트
  * 
  *            -작성 기록-
  *            2021-07-15 : 제작 완료
  *            2021-07-26 : 효과음 추가 완료
  
  *
  * 자식 오브젝트(child)에 접근하는 방법 : transform.GetChild(인덱스) -> 인덱스는 위에서 0부터 시작한다.
  *            
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideBeanStalk : MonoBehaviour
{
    private GameObject mg_Click; //미션유도클릭 오브젝트
    private GameObject mg_giant; //거인 오브젝트
    private int mn_checkAxing = 0; //도끼질 한 후 콩나무 잘린 모습 순서
    private bool mb_checkEnd = false; //Epi14 내용 끝났는지 확인
    private AudioSource GiantSound; // 거인 떨어지면서 나는 소리 
    private AudioSource AxSound; //도끼질 하는 소리
    
    private ScriptControl sc;
    VoiceManager vm;

    // Start is called before the first frame update
    void Start(){
        mg_Click = GameObject.Find("Click (1)"); //Click (1) 게임 오브젝트를 찾아서 mg_Click 변수에 저장
        GameObject g_initBean = transform.GetChild(mn_checkAxing).gameObject; // 부모 오브젝트의 스크립트에서 자식 오브젝트를 가져와서 g_initBean오브젝트에 저장
        g_initBean.SetActive(true); //g_initBean 오브젝트 활성화

        GiantSound = GameObject.Find("GiantSound").GetComponent<AudioSource>();
        AxSound = GameObject.Find("AxSound").GetComponent<AudioSource>();

        sc = ScriptControl.GetInstance(); // Instance 리턴 받아 사용
        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float temp = 0f;
        if(mn_checkAxing > 8) {
            //giant fall.. to y : -1
            if (!mb_checkEnd){ //Epi14 내용 진행중이면
                Destroy(mg_Click); //미션오브젝트 없애기
                mg_giant.transform.position = Vector2.MoveTowards(mg_giant.transform.position,   new Vector2(2f, 0.3f), 2f * Time.deltaTime);
                temp = Mathf.Abs(mg_giant.transform.position.y - 0.3f);
                PlayGiant();

                if( temp <= 0.1f && !mb_checkEnd) {
                    Destroy(mg_giant);
                    Invoke("gotoEpi15Scene", 3.5f); //1초 후 endScene 함수 수행
                    mb_checkEnd = true; //Epi14 내용 끝
                }
            }

        }
        else if(mn_checkAxing == 8) { //콩나무가 다 잘렸으면
            mg_giant = transform.Find("giant").gameObject; //거인오브젝트 찾아서
            mg_giant.SetActive(true); //활성화
            sc.setNextScript(); //다음 스크립트 불러오기
            vm.playVoice(2);
            mn_checkAxing++;
        }

    }
    void OnTriggerExit2D(Collider2D cCheckCollidedObject) {
        if(mn_checkAxing < 8) {
            GameObject g_axedBean = transform.GetChild(mn_checkAxing).gameObject; // 부모 오브젝트의 스크립트에서 자식 오브젝트를 가져와서 g_axedBean오브젝트에 저장
            g_axedBean.SetActive(false); //g_axedBean 오브젝트 비활성화
            mn_checkAxing++;
            AxSound.Play();
            GameObject g_initBean = transform.GetChild(mn_checkAxing).gameObject; // 부모 오브젝트의 스크립트에서 자식 오브젝트를 가져와서 g_initBean오브젝트에 저장
            g_initBean.SetActive(true);//g_initBean 오브젝트 활성화
        }

    }
    void gotoEpi15Scene() {
        SceneManager.LoadScene("Jack_Epi15"); //end_scene 씬 로드
    }

    void PlayGiant(){
        GiantSound.Play();
    }
}
