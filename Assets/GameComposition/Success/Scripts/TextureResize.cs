using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureResize : MonoBehaviour {
    public Texture2D mtx2_resizeTexture;
    void Start()
    {
        GameObject tempImg = transform.GetChild(0).gameObject;
        if(mtx2_resizeTexture is null) {
            RectTransform rt_saveTransform = (RectTransform)this.transform;
            rt_saveTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
            return;
        }
        mtx2_resizeTexture = tempImg.GetComponent<Texture2D>() as Texture2D;
        mtx2_resizeTexture = ScaleTexture(mtx2_resizeTexture, Screen.width, Screen.height);
    }
    private Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight) {
        Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, true);
        Color[] rpixels = result.GetPixels(0);
        float incX = (1.0f / (float)targetWidth);
        float incY = (1.0f / (float)targetHeight);
        for (int px = 0; px < rpixels.Length; px++)
        {
            rpixels[px] = source.GetPixelBilinear(incX * ((float)px % targetWidth), incY * ((float)Mathf.Floor(px / targetWidth)));
        }
        result.SetPixels(rpixels, 0);
        result.Apply();
        return result;
    }
}
