using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutFruits_collideFruitAndBasket : MonoBehaviour {
    // When the fruit collide basket, fruit will be disappeared.
    void OnTriggerEnter2D(Collider2D cCollideObject) {
        if (cCollideObject.tag == "PutFruitInBasket")
        {
            Destroy(this.gameObject);
        }
    }
}