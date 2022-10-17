using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpawnerActivation;
    public GameObject Hexer;
    public GameObject EnemySpell;
    public Transform SpellSummon;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SpawnerActivation = GameObject.FindGameObjectWithTag("SpawnerActivation");

    }
    private void Spellcasting()
    {
        //Instantiate(EnemySpell, SpellSummon.position, SpellSummon.rotation);
        //Move "EnemySpell" towards player's location periodically
    }
}


