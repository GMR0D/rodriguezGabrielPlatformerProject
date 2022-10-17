using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Hexer;
    public Transform HexerPos;
    public Transform EnemySpawnPos;
    public Transform RestartSpawn;

    public void Start()
    {
        Hexer.transform.position = RestartSpawn.position;
    }
    public void EnemySpawn(Vector2 position)
    {
        Hexer.transform.position = EnemySpawnPos.position;
    }
    //public void EnemyRestart(Vector2 position)
    //{
        //Hexer.transform.position = RestartSpawn.position;
    //}
}
