using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideBeanStalk : MonoBehaviour
{
    private int mn_checkAxing = 0;
    private bool mb_checkEnd = false;
    private ScriptControl sc;
    private GameObject giant;
    void OnTriggerExit2D(Collider2D cCheckCollidedObject) {
        if(mn_checkAxing < 8) {
            GameObject axedBean = transform.GetChild(mn_checkAxing).gameObject;
            axedBean.SetActive(false);
            mn_checkAxing++;
            GameObject g_initBean = transform.GetChild(mn_checkAxing).gameObject;
            g_initBean.SetActive(true);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject g_initBean = transform.GetChild(mn_checkAxing).gameObject;
        g_initBean.SetActive(true);
        sc = ScriptControl.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        float temp = 0f;
        if(mn_checkAxing > 8) {
            //giant fall.. to y : -1
            if (!mb_checkEnd){
                giant.transform.position = Vector2.MoveTowards(giant.transform.position,   new Vector2(2f, 0.3f), 2f * Time.deltaTime);
                temp = Mathf.Abs(giant.transform.position.y - 0.3f);
                if( temp <= 0.02f && !mb_checkEnd) {
                    Destroy(giant);
                    Invoke("endScene", 1f);
                    mb_checkEnd = true;
                }
            }

        }
        else if(mn_checkAxing == 8) {
            giant = transform.Find("giant").gameObject;
            giant.SetActive(true);
            sc.setNextScript();
            mn_checkAxing++;
        }

    }
    void endScene() {
        SceneManager.LoadScene("end_scene");
    }
}
