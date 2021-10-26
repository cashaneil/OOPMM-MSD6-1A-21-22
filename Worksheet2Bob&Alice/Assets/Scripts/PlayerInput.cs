using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Enemy bob, alice; //declare bob and alice
    int playerHP = 10; //This is our HP
    
    // Start is called before the first frame update
    void Start()
    {
        //Bob has 5hp, 2 damage, and a name of Bob
        bob = new Enemy(5, 2, "Bob");
        //Alice has 2hp, 5 damage, and a name of Alice
        alice = new Enemy(2, 5, "Alice");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Bob takes damage if Spacebar is pressed
            bob.TakeDamage();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Bob takes damage if left shift is pressed
            alice.TakeDamage();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //player takes damage from Bob if left control (ctrl) is pressed
            //reduces player's HP according to how much damage bob deals
            //playerHP = playerHP - bob.damage;
            playerHP -= bob.damage;
            Debug.Log("Player's HP: " + playerHP);
        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //player takes damage from Alice if left alt is pressed
            //reduces player's HP according to how much damage alice deals
            //playerHP = playerHP - alice.damage;
            playerHP -= alice.damage;
            Debug.Log("Player's HP: " + playerHP);
        }

        if(bob.hitpoints < 1)
        {
            //if bob's HP is less than 1, he dies
            bob.Die();
        }
        
        if (alice.hitpoints < 1)
        {
            //if alice's HP is less than 1, she dies
            alice.Die();
        }

        if (playerHP < 1)
        {
            Debug.Log("You Died!");
        }
    }
}
