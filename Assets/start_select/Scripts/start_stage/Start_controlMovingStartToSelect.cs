using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Start_controlMovingStartToSelect : MonoBehaviour {
    Button mbt_changeStage;

    //when start button clicked, move to the scene of stage selection.
    public void OnClickButton() {
        //Debug.Log("Stage Change!!!");
        SceneManager.LoadScene("select_stage_scene");    
    }

    //dynamic initialize button.. 
    void Start() {
        mbt_changeStage = GetComponent<Button>();
        mbt_changeStage.onClick.AddListener(OnClickButton);
    }
}
