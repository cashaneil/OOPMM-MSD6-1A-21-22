using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody2D body;

    ITakeDamage playerDamageable;
    public int startingHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        playerDamageable = GetComponent<ITakeDamage>();
        playerDamageable.health = startingHealth;
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

    void OnTriggerEnter2D(Collider2D mycollider)
    {
        if (mycollider.gameObject.tag == "Blast")
        {
            Destroy(mycollider.gameObject);

            switch (GameData.CurrentLevel)
            {
                case GameData._currentLevel.Level1:
                    playerDamageable.TakeDamage(5);
                    break;
                case GameData._currentLevel.Level2:
                    playerDamageable.TakeDamage(10);
                    break;
                case GameData._currentLevel.Level3:
                    playerDamageable.TakeDamage(15);
                    break;
            }

            //if (GameData.CurrentLevel == 1)
            //{
            //    playerDamageable.TakeDamage(5);
            //}
            //else if (GameData.CurrentLevel == 2)
            //{
            //    playerDamageable.TakeDamage(10);
            //}
            //else if (GameData.CurrentLevel == 3)
            //{
            //    playerDamageable.TakeDamage(15);
            //}
        }
    }
}
