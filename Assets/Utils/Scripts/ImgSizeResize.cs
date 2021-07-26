/*
 * - Name : ImgSizeResize.cs
 * - Writer : 최대준
 * - Content : 게임화면을 기기의 스크린 사이즈에 맞춰주는 스크립트.
 *          -기록-
 *          2021-07-23 : 주석 작성
 * - ImgSizeResize Member variable
 * Sprite sprImg : 인스펙터 창에서 받은 이미지(배경사진)를 저장하고 있는 변수이다.
 * - ImgSizeResize Member function
 * Start() : 인스펙터 창에서 받은 스프라이트(배경사진)와 캔버스를 기기의 스크린 사이즈에 맞게 조정하도록 초기화 시킨다.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 본 스크립트는 모든 스테이지에서 기기의 스크린에 맞게 배경사진을 맞춰주는 역할을 한다.
public class ImgSizeResize : MonoBehaviour
{
    public Sprite sprImg = null;
    // 인스펙터 창에서 받은 스프라이트(배경사진)와 캔버스를 기기의 스크린 사이즈에 맞게 조정하도록 초기화 시킨다.
    void Start() {
        GameObject tempImg = transform.GetChild(0).gameObject;
        if(sprImg == null) {
            RectTransform rt_saveTransform = (RectTransform)this.transform;
            rt_saveTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
            return;
        }
        Image img = tempImg.GetComponent<Image>() as Image;
        img.sprite = sprImg;
        RectTransform rt_saveImgTransform = (RectTransform)tempImg.transform;
        rt_saveImgTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
