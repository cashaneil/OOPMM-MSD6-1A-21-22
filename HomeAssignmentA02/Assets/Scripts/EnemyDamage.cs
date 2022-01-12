using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour, ITakeDamage
{
    public int health { get; set; }

    public void TakeDamage(int DamageAmount)
    {
        health = health - DamageAmount;
        if (gameObject.tag == "Player")
        {
            GameManager._instance.UpdateHealthText(health);
        }
        Debug.Log(gameObject.tag+"'s new health is: "+health);
        if (health <= 0)
        {
            //if player is taking damage
            if (gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
            }
            //if enemy is taking damage
            else if (gameObject.tag == "Enemy")
            {
                GameManager._instance.IncreaseScore(25);
                Destroy(this.gameObject);
            }
        }
    }
}
