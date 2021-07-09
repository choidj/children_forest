using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ra_checkMouseDistance = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D h_hitDistanceCast2D = Physics2D.GetRayIntersection(ra_checkMouseDistance, Mathf.Infinity);

            if (h_hitDistanceCast2D.collider != null && h_hitDistanceCast2D.collider.name == "backController")
            {
                SceneManager.LoadScene("select_stage_scene");
            }
        }
    }
}
