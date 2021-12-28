using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float speed;

    private Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get movement amount from input
        float movementInput = getMovementInput();

        //determine amount to move based on current right direction and speed
        Vector2 movement = transform.right * movementInput * speed * Time.deltaTime;

        //keep player y-axis at 0 with movement
        movement.y = 0f;

        //move player rigidbody to movement position
        body.MovePosition(body.position + movement);
    }

    float getMovementInput()
    {
        //player moves forward and back with A and D; 
        KeyCode forwardKey = KeyCode.D;
        KeyCode backKey = KeyCode.A;

        if (Input.GetKey(forwardKey))
        {
            return 1f;
        }
        else if (Input.GetKey(backKey))
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }
}
