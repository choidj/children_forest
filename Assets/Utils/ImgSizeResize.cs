using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgSizeResize : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite sprImg;
    void Start()
    {
        GameObject tempImg = transform.GetChild(0).gameObject;
        if(sprImg is null) {
            RectTransform rt_saveTransform = (RectTransform)this.transform;
            rt_saveTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
            return;
        }
        Image img = tempImg.GetComponent<Image>() as Image;
        img.sprite = sprImg;
        RectTransform rt_saveImgTransform = (RectTransform)tempImg.transform;
        rt_saveImgTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
