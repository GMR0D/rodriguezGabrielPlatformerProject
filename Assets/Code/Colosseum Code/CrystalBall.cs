using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBall : MonoBehaviour
{
    public Vector2 leftLimit;
    public Vector2 rightLimit;
    public float speed = 3;
    public bool left;
    void Update()
    {
        InvokeRepeating("Rotation", 0, 1);
        if (left) //Is it moving left/Is Left true?
        {
            transform.position = Vector2.MoveTowards(transform.position, leftLimit, speed * Time.deltaTime); //"Time.deltaTime" = Amount of time passed between each frame (neccesary for frame-by-frame movement)
            if (transform.position.x <= leftLimit.x) //Is current position past the left limit?
            {
                left = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, rightLimit, speed * Time.deltaTime);
            if (transform.position.x >= rightLimit.x)
            {
                left = true;
            }
        }
    }
    private void Rotation()
    {
        Vector3 rotationAdd = new Vector3(0, 0, 15);
        transform.Rotate(rotationAdd);
    }
}
