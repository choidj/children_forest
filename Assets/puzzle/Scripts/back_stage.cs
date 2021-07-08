using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back_stage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){  //업데이트 문에다 넣어줘야함 . 
        SceneManager.LoadScene("뒤로갈 씬 이름 "); // 씬으로 이동 .
  
    }
}
