using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    protected float speed;

    private Vector2 direction;

    protected virtual void OnTriggerEnter2D(Collider2D mycollider)
    {
        if (mycollider.gameObject.name == "Main Camera")  //if blast collides with Main Camera, destroy it
        {
            Destroy(gameObject);
        }
        else if (mycollider.gameObject.tag == "Blast")  //if blast collides with another blast (ex. player/enemy blast), destroy the opposing blast and itself
        {
            Destroy(mycollider.gameObject);
            Destroy(gameObject);
        }
    }

    protected virtual void BlastToTarget(Vector3 targetPos)
    {
        //determine velocity based on mouse position
        direction = targetPos - this.transform.position;
        direction.Normalize();
        Vector2 newvelocity = direction * speed;
        this.GetComponent<Rigidbody2D>().velocity = newvelocity;

        Quaternion blastrotation = Quaternion.LookRotation((this.transform.position - targetPos), Vector3.forward);
        blastrotation.x = 0f;
        blastrotation.y = 0f;

        this.transform.rotation = blastrotation;
    }
}