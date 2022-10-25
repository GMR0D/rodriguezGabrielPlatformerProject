using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mountainside : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            SceneManager.LoadScene(4);
        }
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}