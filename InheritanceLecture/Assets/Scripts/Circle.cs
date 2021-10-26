using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Shape
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        xpos = 8f;
        ypos = 4f;
        base.ResetPosition(rb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
