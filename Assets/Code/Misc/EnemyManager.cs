using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Hexer;
    public Transform HexerPos;
    public Transform EnemySpawnPos;
    public Transform RestartSpawn;
    public GameObject EnemySpell;
    public Transform Player;
    public GameObject SpawnerActivation;
    public GameObject PlayerSprite;
    public Transform SpellSummon;

    public float Speed = 2;
   
    public void EnemyRestart(Vector2 position)
    {
        Hexer.transform.position = RestartSpawn.position;
    }
}
