/*
 * - Name : PutFruits_initializeStage.cs
 * - Writer : 최대준
 * - Content : PutFruits_initializeStage 클래스에서는 이름에서와 같이 씬에 필요한 Fruit 프리팹을 정해진 갯수만큼 생성하고 Fruit 프리팹의 위치를 랜덤하게 주도록 하였다.
 * - Where the code is applied : /Asset/fruit_putin/Scenes/put_fruits_scene -> StageControl
 *             -사용법-
 *            1. 빈 게임 오브젝트에 스크립트 코드를 드래그하여 넣어주면 된다.
 *            -작성 기록-
 *            2021-07-19 : 제작 완료
 *            2021-07-20 : 주석 처리
 *
 * - PutFruits_initializeStage Member Variable 
 * GameObject mg_instanceFruit : 이 클래스를 이용하여 Fruit 프리팹에 맞는 음성을 출력할 수 있게 된다.
 * int mn_countFruits : Fruit 프리팹의 종류를 나타내주는 id 변수이다.
 * Sprite[] msa_changeSpritesImg : Fruit 프리팹이 처음 생성된 위치를 저장하는 변수이다.
 * bool mb_stopUpdating : Fruit 프리팹이 드래그중인지 아닌지를 판단하는 변수이다.
 * Text mt_putFruitSize : 
 * List<GameObject> mlg_fruitList : 
 * 
 * - PutFruits_initializeStage Member Function
 * Start() : 이 빈 게임 오브젝트가 생성될 때, Fruit 프리팹을 정해진 개수 (mn_countFruits) 만큼 랜덤한 위치에 생성하도록 하였다.
 * Update() : 오브젝트가 씬에 생성되면 계속 호출되는 함수로, 생성된 Fruit 프리팹의 개수를 세어 UI에 개수를 표시하도록 한다.
 * v_changeEndingScene() : 플레이어가 씬에 있는 모든 과일을 바구니에 넣었다면, 게임이 종료되며 준비해 놓은 end_scene으로 넘어가도록 하였다.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// 본 클래스는 과일 넣기 스테이지에 과일을 생성하고 랜덤한 위치로 보내는 역할, 과일의 개수를 세어 ui에 출력해주는 역할을 하는 클래스이다.
public class PutFruits_initializeStage : MonoBehaviour {
    public GameObject mg_instanceFruit;

    public int mn_countFruits = 10;
    public Sprite[] msa_changeSpritesImg = new Sprite[5];
    private bool mb_stopUpdating = true;
    private TextMesh mtm_putFruitSize;
    private List<GameObject> mlg_fruitList = new List<GameObject>();

    // When fruitPutIn stage start, random initializing position of fruits.
    void Start() {
        mtm_putFruitSize = GameObject.Find("PutFruitsSize").GetComponent<TextMesh>() as TextMesh;
        mtm_putFruitSize.text = mn_countFruits.ToString();

        for (int i = 0; i < mn_countFruits; i++) {
            GameObject fruit = Instantiate(mg_instanceFruit);
            fruit.transform.position = new Vector2(Random.Range(-8f, 8f),
                Random.Range(-4f, 4f));
            int tempNum = Random.Range(0, 5);
            fruit.GetComponent<SpriteRenderer>().sprite = msa_changeSpritesImg[tempNum];
            ControlFruit temp = fruit.GetComponent(typeof(ControlFruit)) as ControlFruit;
            temp.setFruitId(tempNum * 2);
            mlg_fruitList.Add(fruit);
        }
    }

    // check size of fruits... and update number of text object to n_countFruits...
    void Update() {
        int n_countFruits = 10;

        for(int i = 0; i < mn_countFruits; i++) {
            if (mlg_fruitList[i] == null) {
                n_countFruits--;
            }
        }

        mtm_putFruitSize.text = n_countFruits.ToString();

        if(n_countFruits == 0 && mb_stopUpdating) {
            mb_stopUpdating = false;
            // when the time goes 2 seconds later, call the changeEndingScene function..
            Invoke("v_changeEndingScene", 2f);
        }
    }
    //when the scene is completed, change this scene to ending scene..
    void v_changeEndingScene() {
        SceneManager.LoadScene("end_scene");
    }
}
