/*
 * - Name : ControlFruit.cs
 * - Writer : 최대준
 * - Content : ControlFruit 클래스에서는 이름에서와 같이 생성된 Fruit 프리팹을 컨트롤하기 위한 클래스이다. Fruit 프리팹을 사용자가 드래그하면 Fruit가 따라오고, tts 음성 출력을 위한 Fruit의 id를 가지고 있다.
* - Where the code is applied : /Asset/fruit_putin/Prefab/Fruit
 *             -사용법-
 *            1. Fruit 프리팹을 씬에다가 추가한다. 프리팹에는 컴포넌트로 스크립트가 적용되어 있다.
 *            -작성 기록-
 *            2021-07-19 : 제작 완료
 *            2021-07-20 : 주석 처리
 *            2021-07-23 : SoundManager 추가.
 *
 * - ControlFruit Member Variable 
 * VoiceManager mvm_voiceManager : 이 클래스를 이용하여 Fruit 프리팹에 맞는 음성을 출력할 수 있게 된다.
 * int mn_fruitId : Fruit 프리팹의 종류를 나타내주는 id 변수이다.
 * Vector2 mv2_remembPos : Fruit 프리팹이 처음 생성된 위치를 저장하는 변수이다.
 * bool mb_checkClickOnce : Fruit 프리팹이 드래그중인지 아닌지를 판단하는 변수이다.
 * SoundManager msm_soundManager : 효과음 관리하는 클래스이다.
 * 
 * - ControlFruit Member Function
 * Start() : Fruit 게임 오브젝트가 생성될 때 최초로 실행되는 함수로, VoiceManager 클래스의 인스턴스를 가지고 있게 된다.
 * Update() : 오브젝트가 씬에 생성되면 계속 호출되는 함수로, 계속 처음에 생성된 위치로 가려고 하게 하였다. 이는 과일의 캐릭터가 억지로 플레이어에게 잡힌거처럼 연출하기 위해서이다.
 * OnMouseDrag() : 플레이어가 과일을 드래그할때 호출되는 함수로 마우스 위치로 Fruit 프리팹을 옮기게 하여 끌려가는 행위를 표현하였다.
 * OnMouseUp() : 플레이어가 드래그에서 손을 뗐을 때 mb_checkClickOnce를 true로 만들어 계속 음성이 출력되지 않고 한번만 출력이 되게 예외처리를 해주었다.
 * OnTriggerEnter2D(Collider2D cCollideObject) : 유니티의 collider 컴포넌트를 주었을 때 호출되는 함수로, 이름과 같이 collider들이 부딪혔을 때 호출되어 함수안에 어떤 작업을 할지를 적어주는 함수로, 나는 부딪혔을 때, 현재 이 스크립트를 가진 오브젝트인 Fruit 프리팹이 사라지게 하고, 과일 종류에 따른 영어 음성을 출력하도록 하였다.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fruit 프리팹의 상태, 행동들을 컨트롤하는 스크립트 클래스이다.
public class ControlFruit : MonoBehaviour {
    private VoiceManager mvm_voiceManager;
    private SoundManager msm_soundManager;
    public int mn_fruitId;
    private Vector2 mv2_remembPos;
    private bool mb_checkClickOnce = false;
    // VoiceManager 클래스를 초기화하고, 처음 초기화 위치를 저장한다. (다시 돌아가기 위해서)
    void Start() {
        mvm_voiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
        msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        mv2_remembPos = gameObject.transform.position;
    }
    // 초기화한 자리로 이동하도록 하였다. (드래그해서 다른 위치로 옮기면, 서서히 다시 처음 위치로 돌아가도록 한 것이다.)
    void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv2_remembPos, 2f * Time.deltaTime);
    }
    // 드래그시에 호출되는 함수로, 드래그할 시에 무슨 과일인지 이름을 음성으로 출력하게 하였다.
    private void OnMouseDrag() {
        if(!mb_checkClickOnce) {
            mvm_voiceManager.playVoice(mn_fruitId); //한국 보이스 출력
            msm_soundManager.playSound(0);
            mb_checkClickOnce = true;
        }
        Vector2 v2_checkMousePos = new Vector2(Input.mousePosition.x,
        Input.mousePosition.y);
        Vector2 v2_checkworldObjPos = Camera.main.ScreenToWorldPoint(v2_checkMousePos);
        this.transform.position = v2_checkworldObjPos;
    }
    // 드래그시에 호출되는 함수는 드래그시에는 계속 호출되므로 음성 또한 계속 출력되어서, 이러한 예외처리를 두었다.
    void OnMouseUp() {
        msm_soundManager.playSound(1);
        msm_soundManager.playSound(2);
        mb_checkClickOnce = false;
    }
    // PutFruits_initializeStage라는 클래스에서 총 이 Fruit 프리팹들을 생성할 때 이 프리팹이 어떤 종류의 과일인지를 이 함수를 통해 멤버 변수 mn_fruitId로 넣게 된다.
    public void setFruitId(int nId) {
        mn_fruitId = nId;
    }
    // Fruit와 Basket의 충돌이 일어났을 때 호출되는 함수로, 여기서는 Fruit를 사라지게하고, 영어로 된 음성을 출력하도록 하였다.
    void OnTriggerEnter2D(Collider2D cCollideObject) {
        if (cCollideObject.tag == "PutFruitInBasket")
        {
            mvm_voiceManager.playVoice(mn_fruitId+1); //영어
            Destroy(this.gameObject);
        }
    }
}