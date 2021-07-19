using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_nextpage : MonoBehaviour
{
    public string ms_nameNextScene;
    void OnTriggerEnter2D(Collider2D cCollideObject)
    {
        SceneManager.LoadScene("Jack_Epi3");
    }
}
