using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    public Vector2 LeftLimit;
    public Vector2 RightLimit;
    public float Speed = 3;
    public bool Left;
    void Update()
    {
        if (Left) //Is it moving left/Is Left true?
        {
            transform.position = Vector2.MoveTowards(transform.position, LeftLimit, Speed * Time.deltaTime); //"Time.deltaTime" = Amount of time passed between each frame (neccesary for frame-by-frame movement)
            if (transform.position.x <= LeftLimit.x) //Is current position past the left limit?
            {
                Left = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, RightLimit, Speed * Time.deltaTime);
            if (transform.position.x >= RightLimit.x)
            {
                Left = true;
            }
        }
    }
}
