using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PutFruits_initializeStage : MonoBehaviour {
    public GameObject mg_instanceFruit;

    public int mn_countFruits = 10;
    public Sprite[] msa_changeSpritesImg = new Sprite[5];
    private TTS mtts_getFruitNameVoice;
    private AudioClip[] macl_ENsaveFruitNameVoiceList = new AudioClip[5];
    private AudioClip[] macl_KRsaveFruitNameVoiceList = new AudioClip[5];
    private bool mb_stopUpdating = true;
    private Text mt_putFruitSize;
    private List<GameObject> mlg_fruitList = new List<GameObject>();

    // When fruitPutIn stage start, random initializing position of fruits.
    void Start() {
        mt_putFruitSize = GameObject.Find("PutFruitSize").GetComponent<Text>();
        mt_putFruitSize.text = mn_countFruits.ToString();

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

        mt_putFruitSize.text = n_countFruits.ToString();

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
