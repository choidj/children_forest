using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_controlStages : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ra_checkMouseDistance = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D h_hitDistanceCast2D = Physics2D.GetRayIntersection(ra_checkMouseDistance, Mathf.Infinity);

            if (h_hitDistanceCast2D.collider != null && h_hitDistanceCast2D.collider.tag == "Stage")
            {
                string[] strTmp = h_hitDistanceCast2D.collider.name.Split('_');
                switch (strTmp[0])
                {
                    case "brush":
                        SceneManager.LoadScene("clean_teeth_scene");
                        break;
                    case "mart":
                        SceneManager.LoadScene("buy_mart_scene");
                        break;
                    case "match":
                        SceneManager.LoadScene("match_shape_scene");
                        break;
                    case "puzzle":
                        SceneManager.LoadScene("solve_puzzle_scene");
                        break;
                    case "reading":
                        SceneManager.LoadScene("reading_scene");
                        break;
                    case "fruit":
                        SceneManager.LoadScene("put_fruits_scene");
                        break;
                    case "lock":
                        Debug.Log("lock stage is clicked.....");
                        break;
                }
            }
        }
    }
}