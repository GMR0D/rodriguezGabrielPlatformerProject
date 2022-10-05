using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.S)) //"Select Character" menu
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.H)) //"How To Play" menu
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKey(KeyCode.Q)) //Quit
        {
            Application.Quit();
        }
    }
}