using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FruitPutInStageControl : MonoBehaviour {
    public GameObject mg_instanceFruit;

    public int mn_countFruits = 10;
    public Sprite[] msa_changeSpritesImg = new Sprite[5];

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
            fruit.GetComponent<SpriteRenderer>().sprite = msa_changeSpritesImg[Random.Range(0, 4)];
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
            Invoke("changeEndingScene", 2f);
        }
    }
    void changeEndingScene() {
        SceneManager.LoadScene("end_scene");
    }
}
