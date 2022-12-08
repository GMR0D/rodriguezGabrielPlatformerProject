using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistMove : MonoBehaviour
{
    public float speed = 3;
    public const float scrollingWidth = 8;
    public Vector2 leftLimit;
    public Vector2 spawn;

    private void Start()
    {
        Vector3 MistSpawn = spawn;
        transform.position = MistSpawn;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, leftLimit, speed * Time.deltaTime);

        if (transform.position.x <= leftLimit.x)
        {
            Vector3 MistSpawn = spawn;
            transform.position = MistSpawn;
        }
    }
}
