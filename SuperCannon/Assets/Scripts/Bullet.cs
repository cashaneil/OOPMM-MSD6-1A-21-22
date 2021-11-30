using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed;

    private Vector2 direction;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Vector2 is used for the position and velocity of RIGIBODY 2D
        //Vector3 is used for the position of game objects

        Vector3 mousepos = GameData.MousePos;

        //add code here to decide velocity based on mouse position
        direction = mousepos - this.transform.position;
        direction.Normalize();
        Vector2 newvelocity = direction * speed;
        this.GetComponent<Rigidbody2D>().velocity = newvelocity;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D mycollider)
    {
        if(mycollider.gameObject.name == "Collider")  //if bullet collides with Game Object of name 'Collider', destroy it
        {
            Destroy(gameObject);
        }
    }
}