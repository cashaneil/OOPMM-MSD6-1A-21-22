using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ITakeDamage damageable;
    [SerializeField] int starthealth;
    
    // Start is called before the first frame update
    void Start()
    {
        damageable = GetComponent<ITakeDamage>();
        damageable.health = starthealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D mycollider)
    {
        if (mycollider.gameObject.tag == "Bullet")  //if enemy collides with Game Object tagged as 'Bullet', destroy it
        {
            Destroy(mycollider.gameObject);
            damageable.TakeDamage(1);
        }

        if (mycollider.gameObject.tag == "Floor") //if enemy collides with Game Object tagged as 'Floor'(EnemyDestroyer), destroy it
        {
            Destroy(this.gameObject); //destroy the enemy
        }
    }
}
