using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeTheScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }
}
