using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ITakeDamage enemyDamageable;
    [SerializeField] int startingHealth;

    //player prefab
    GameObject playerPrefab;
    //blasts list
    [SerializeField] List<GameObject> BlastList;

    // Start is called before the first frame update
    void Start()
    {
        //Assigning enemies random speed to the left
        Vector2 enemyVelocity = new Vector2(UnityEngine.Random.Range(-2.0f, -7.0f), 0f);
        this.GetComponent<Rigidbody2D>().velocity = enemyVelocity;

        enemyDamageable = GetComponent<ITakeDamage>();
        enemyDamageable.health = startingHealth;

        playerPrefab = GameObject.FindGameObjectWithTag("Player");

        blastToPlayer();
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

            switch (GameData.CurrentLevel)
            {
                case GameData._currentLevel.Level1:
                    enemyDamageable.TakeDamage(5);
                    break;

                case GameData._currentLevel.Level2:
                    enemyDamageable.TakeDamage(7);
                    break;

                case GameData._currentLevel.Level3:
                    enemyDamageable.TakeDamage(9);
                    break;
            }
        }
    }

    //fire a blast towards the player
    void blastToPlayer()
    {
        //level 1 blast
        int blastToSpawn = 0;

        switch (GameData.CurrentLevel)
        {
            case GameData._currentLevel.Level2:
                blastToSpawn = 1;
                break;

            case GameData._currentLevel.Level3:
                blastToSpawn = 2;
                break;
        }

        Vector3 enemyTip = new Vector3(transform.position.x, transform.position.y - 2f);
        GameObject spawnedBlast = Instantiate(BlastList[blastToSpawn], enemyTip, Quaternion.identity);
        //blast must be given a direction velocity
        //in this case it is from the enemy to the player position
        //run BlastToTarget with parameter of player pos
        try
        {
            spawnedBlast.SendMessage("BlastToTarget", playerPrefab.transform.position);
        }
        catch (NullReferenceException)
        {
            Debug.Log("Player prefab not found; cannot point enemy blast");
        }
    }
}
