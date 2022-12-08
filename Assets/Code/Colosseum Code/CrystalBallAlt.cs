using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBallAlt : MonoBehaviour
{
    public Vector2 upLimit;
    public Vector2 downLimit;
    public float speed = 3;
    public bool up;
    void Update()
    {
        InvokeRepeating("Rotation", 0, 1);
        if (up)
        {
            transform.position = Vector2.MoveTowards(transform.position, downLimit, speed * Time.deltaTime);
            if (transform.position.y <= downLimit.y) //Is current position past the left limit?
            {
                up = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, upLimit, speed * Time.deltaTime);
            if (transform.position.y >= upLimit.y)
            {
                up = true;
            }
        }
    }
    private void Rotation()
    {
        Vector3 rotationAdd = new Vector3(0, 0, 15);
        transform.Rotate(rotationAdd);
    }
}