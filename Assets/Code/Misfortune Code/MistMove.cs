using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistMove : MonoBehaviour
{
    public float Speed = 3;
    public const float ScrollingWidth = 8;
    public Vector2 LeftLimit;
    public Vector2 Spawn;

    private void Start()
    {
        Vector3 MistSpawn = Spawn;
        transform.position = MistSpawn;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, LeftLimit, Speed * Time.deltaTime);

        if (transform.position.x <= LeftLimit.x)
        {
            Vector3 MistSpawn = Spawn;
            transform.position = MistSpawn;
        }
    }
}
