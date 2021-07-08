using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEffect : MonoBehaviour
{
    public GameObject mg_playEffectObj;

    // When the fruit collide basket, fruit will be disappeared.
    void OnTriggerEnter2D(Collider2D cCollideObject)
    {
        if (cCollideObject.tag == "PutFruitInBasket")
        {
            Instantiate(mg_playEffectObj, transform.position, Quaternion.identity);
            Destroy(mg_playEffectObj, 1f);
        }
    }
}
