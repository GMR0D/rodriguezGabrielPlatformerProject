using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpawnerActivation;
    public Transform Spawn;
    public GameObject Hexer;

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SpawnerActivation = GameObject.FindGameObjectWithTag("SpawnerActivation");


        //if Player collides with SpawnerActivation...Instantiate(Hexer, Spawn.position, Spawn.rotation);
    }
}

