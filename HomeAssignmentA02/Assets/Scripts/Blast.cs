using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    protected float speed;

    private Vector2 direction;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Vector3 mousepos = GameData.MousePos;

        //determine velocity based on mouse position
        direction = mousepos - this.transform.position;
        direction.Normalize();
        Vector2 newvelocity = direction * speed;
        this.GetComponent<Rigidbody2D>().velocity = newvelocity;

        Quaternion blastrotation = Quaternion.LookRotation((this.transform.position - mousepos), Vector3.forward);
        blastrotation.x = 0f;
        blastrotation.y = 0f;

        this.transform.rotation = blastrotation;
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D mycollider)
    {
        if (mycollider.gameObject.name == "Main Camera")  //if blast collides with Main Camera, destroy it
        {
            Destroy(gameObject);
        }
    }
}