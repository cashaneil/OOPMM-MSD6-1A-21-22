using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyTakeDamage damageable;
    [SerializeField] int startingHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        //Assigning enemies random speed to the left
        Vector2 enemyVelocity = new Vector2(Random.Range(-2.0f, -7.0f), 0f);
        this.GetComponent<Rigidbody2D>().velocity = enemyVelocity;

        damageable = GetComponent<EnemyTakeDamage>();
        damageable.health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D mycollider)
    {
        if (mycollider.gameObject.tag == "Destroyer") //if enemy collides with EnemyDestroyer, destroy it
        {
            Destroy(this.gameObject); //destroy the enemy
        }

        if (mycollider.gameObject.tag == "Blast")
        {
            Destroy(mycollider.gameObject);
            damageable.TakeDamage(2);
        }
    }
}
