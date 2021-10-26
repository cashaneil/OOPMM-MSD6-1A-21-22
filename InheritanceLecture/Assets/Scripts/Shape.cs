using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    protected float xpos, ypos, xspeed, yspeed;

    protected void MoveLeft(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(-xspeed, 0);
    }

    protected void MoveRight(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(xspeed, 0);
    }

    protected void MoveUp(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(0, yspeed);
    }

    protected void MoveDown(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(0, -yspeed);
    }

    protected void ResetPosition(Rigidbody2D rb)
    {
        rb.position = new Vector2(xpos, ypos);

    }
}
