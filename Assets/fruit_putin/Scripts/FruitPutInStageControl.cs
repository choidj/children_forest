using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitPutInStageControl : MonoBehaviour {
    public GameObject mg_instanceFruit;
    public int mn_countFruits = 10;
    private Text mt_putFruitSize;
    private List<GameObject> ml_fruitList = new List<GameObject>();
    public Sprite[] msl_changeSpritesImg = new Sprite[5];

    // When fruitPutIn stage start, random initializing position of fruits.
    void Start() {
        mt_putFruitSize = GameObject.Find("PutFruitSize").GetComponent<Text>();
        mt_putFruitSize.text = mn_countFruits.ToString();
        for (int i = 0; i < mn_countFruits; i++) {
            GameObject fruit = Instantiate(mg_instanceFruit);
            fruit.transform.position = new Vector2(Random.Range(-8f, 8f),
                Random.Range(-4f, 4f));
            fruit.GetComponent<SpriteRenderer>().sprite = msl_changeSpritesImg[Random.Range(0, 4)];
            ml_fruitList.Add(fruit);
        }
    }

    // check size of fruits... and update number of text object to n_countFruits...
    void Update() {
        int n_countFruits = 10;
        for(int i = 0; i < mn_countFruits; i++) {
            if (ml_fruitList[i] == null) {
                n_countFruits--;
            }
        }
        mt_putFruitSize.text = n_countFruits.ToString();
    }
}
