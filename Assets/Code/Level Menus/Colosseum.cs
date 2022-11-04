using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colosseum : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}