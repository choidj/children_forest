/*
  * - Name : Movement_Giant.cs
  * - Writer : 이윤교
  * - Content : 잭과콩나무 에피소드14 - 콩나무 도끼질 하며 자르기 스크립트
  * 
  *            -작성 기록-
  *            2021-07-15 : 제작 완료
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
    private GameObject giant; //거인 오브젝트
    private int mn_checkAxing = 0; //도끼질 한 후 콩나무 잘린 모습 순서
    private bool mb_checkEnd = false;
    
    private ScriptControl sc;

    void OnTriggerExit2D(Collider2D cCheckCollidedObject) {
        if(mn_checkAxing < 8) {
            GameObject g_axedBean = transform.GetChild(mn_checkAxing).gameObject; // 부모 오브젝트의 스크립트에서 자식 오브젝트를 가져와서 g_axedBean오브젝트에 저장
            g_axedBean.SetActive(false); //g_axedBean 오브젝트 비활성화
            mn_checkAxing++;
            GameObject g_initBean = transform.GetChild(mn_checkAxing).gameObject; // 부모 오브젝트의 스크립트에서 자식 오브젝트를 가져와서 g_initBean오브젝트에 저장
            g_initBean.SetActive(true);//g_initBean 오브젝트 활성화
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        mg_Click = GameObject.Find("Click (1)"); //Click (1) 게임 오브젝트를 찾아서 mg_Click 변수에 저장
        GameObject g_initBean = transform.GetChild(mn_checkAxing).gameObject; // 부모 오브젝트의 스크립트에서 자식 오브젝트를 가져와서 g_initBean오브젝트에 저장
        g_initBean.SetActive(true); //g_initBean 오브젝트 활성화
        sc = ScriptControl.GetInstance(); // Instance 리턴 받아 사용
    }

    // Update is called once per frame
    void Update()
    {
        float temp = 0f;
        if(mn_checkAxing > 8) {
            //giant fall.. to y : -1
            if (!mb_checkEnd){
                Destroy(mg_Click);
                giant.transform.position = Vector2.MoveTowards(giant.transform.position,   new Vector2(2f, 0.3f), 2f * Time.deltaTime);
                temp = Mathf.Abs(giant.transform.position.y - 0.3f);

                if( temp <= 0.02f && !mb_checkEnd) {
                    Destroy(giant);
                    Invoke("endScene", 1f);
                    mb_checkEnd = true;
                }
            }

        }
        else if(mn_checkAxing == 8) {
            giant = transform.Find("giant").gameObject;
            giant.SetActive(true);
            sc.setNextScript();
            mn_checkAxing++;
        }

    }
    void endScene() {
        SceneManager.LoadScene("end_scene");
    }
}
