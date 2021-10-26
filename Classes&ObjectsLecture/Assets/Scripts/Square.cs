using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    Rigidbody2D myrb;
    Shape mysquare = new Shape(3.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        myrb = this.gameObject.GetComponent<Rigidbody2D>();

        //instead of this
        //myrb.velocity = new Vector2(-3.0f, 0.0f);
        mysquare.MoveRight(myrb);
    }

    void OnCollisionEnter2D(Collision2D mycollider)
    {
        mysquare.SpeedDoubling(myrb);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
