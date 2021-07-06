using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matching : MonoBehaviour
{
    public int mn_id = 0;
    public bool mb_classifyWhetherAns = false;
    public Sprite[] msl_changeAnsImg = new Sprite[4];

    void OnTriggerEnter2D(Collider2D cCollideObject) {
        if(cCollideObject.GetComponent<Matching>().mn_id == this.mn_id) {
            if (mb_classifyWhetherAns) {
                gameObject.GetComponent<Image>().sprite = msl_changeAnsImg[mn_id];
            }
            else {
                Destroy(this.gameObject);
            }
        }

    }
}
