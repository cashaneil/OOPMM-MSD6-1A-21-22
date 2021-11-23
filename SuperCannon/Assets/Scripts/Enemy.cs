using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Assigning enemies random speed downwards
        Vector2 enemyVelocity = new Vector2(0f, Random.Range(-4.0f, -9.0f));
        this.GetComponent<Rigidbody2D>().velocity = enemyVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D mycollider)
    {
        if (mycollider.gameObject.tag == "Bullet")  //if bullet collides with Game Object of name 'Collider', destroy it
        {
            Destroy(gameObject);

            GameData.AddScorebyEnemy(gameObject.name);
        }
    }
}
