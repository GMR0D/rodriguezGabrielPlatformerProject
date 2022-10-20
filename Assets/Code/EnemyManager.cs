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
    public Transform SpellSummon;
    public GameObject SpawnerActivation;

    public float Speed = 0.01f;


    public void Start()
    {
        Hexer.transform.position = RestartSpawn.position;
        SpawnerActivation = GameObject.FindGameObjectWithTag("SpawnerActivation");
    }
    
    public void EnemySpawn(Vector2 position)
    {
        Hexer.transform.position = EnemySpawnPos.position;
        InvokeRepeating("Spellcasting", 0, 1.1f);
    }
    private void Spellcasting()
    {
        GameObject NewEnemySpell = Instantiate(EnemySpell, SpellSummon.position, SpellSummon.rotation);
        Vector2 velocity = new Vector2((transform.position.x + Player.transform.position.x) * Speed, (transform.position.y - Player.transform.position.y) * Speed);
        NewEnemySpell.GetComponent<Rigidbody2D>().velocity = velocity;
        Destroy(NewEnemySpell, 2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerSpell")
        {
            Destroy(Hexer);
            Destroy(SpellSummon);
        }
    }
    public void EnemyRestart(Vector2 position)
    {
        Hexer.transform.position = RestartSpawn.position;
    }
}
