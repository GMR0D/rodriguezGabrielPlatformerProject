using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimits : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerposition = new Vector3(((Player.transform.position.x) + 6.55f), -0.23f, -10);
        transform.position = playerposition;
    }
}
