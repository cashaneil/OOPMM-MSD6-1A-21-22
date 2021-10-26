using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape
{
    private Vector2 speed = new Vector2(0f, 0f);

    public Shape(float x, float y)
    {
        speed = new Vector2(x, y);
    }

    public void MoveLeft(Rigidbody2D myshape)
    {
        myshape.velocity = -speed;
    }

    public void MoveRight(Rigidbody2D myshape)
    {
        myshape.velocity = speed;
    }

    public void SpeedDoubling(Rigidbody2D myshape)
    {
        myshape.velocity = new Vector2((myshape.velocity.x * 2f), 0.0f);
    }
}
