using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBallAlt : MonoBehaviour
{
    public Vector2 UpLimit;
    public Vector2 DownLimit;
    public float Speed = 3;
    public bool Up;
    void Update()
    {
        InvokeRepeating("Rotation", 0, 1);
        if (Up)
        {
            transform.position = Vector2.MoveTowards(transform.position, DownLimit, Speed * Time.deltaTime);
            if (transform.position.y <= DownLimit.y) //Is current position past the left limit?
            {
                Up = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, UpLimit, Speed * Time.deltaTime);
            if (transform.position.y >= UpLimit.y)
            {
                Up = true;
            }
        }
    }
    private void Rotation()
    {
        Vector3 rotationAdd = new Vector3(0, 0, 15);
        transform.Rotate(rotationAdd);
    }
}