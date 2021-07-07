using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainToStageSelect : MonoBehaviour {
    Button mb_changeStageButton;

    //when start button clicked, move to the scene of stage selection.
    public void OnClickButton() {
        //Debug.Log("Stage Change!!!");
        SceneManager.LoadScene("fruit_putin");    
    }

    //dynamic initialize button.. 
    void Start() {
        mb_changeStageButton = GetComponent<Button>();
        mb_changeStageButton.onClick.AddListener(OnClickButton);
    }
}
