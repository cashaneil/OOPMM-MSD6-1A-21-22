using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ITakeDamage enemyDamageable;
    [SerializeField] int startingHealth;

    //player prefab
    GameObject playerPrefab;
    //Blast1 prefab
    GameObject Blast1;

    // Start is called before the first frame update
    void Start()
    {
        //Assigning enemies random speed to the left
        Vector2 enemyVelocity = new Vector2(Random.Range(-2.0f, -7.0f), 0f);
        this.GetComponent<Rigidbody2D>().velocity = enemyVelocity;

        enemyDamageable = GetComponent<ITakeDamage>();
        enemyDamageable.health = startingHealth;

        Blast1 = Resources.Load("L1Blast") as GameObject;

        playerPrefab = GameObject.FindGameObjectWithTag("Player");

        blastToPlayer();
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
            enemyDamageable.TakeDamage(5);
        }
    }

    //fire a blast towards the player
    void blastToPlayer()
    {
        Vector3 enemyTip = new Vector3(transform.position.x, transform.position.y - 1f);
        GameObject spawnedBlast = Instantiate(Blast1, enemyTip, Quaternion.identity);
        //blast must be given a direction velocity
        //in this case it is from the enemy to the player position
        //run BlastToTarget with parameter of player pos
        spawnedBlast.SendMessage("BlastToTarget", playerPrefab.transform.position);
    }
}
