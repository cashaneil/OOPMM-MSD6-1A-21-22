using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1EnemyDamage : MonoBehaviour, EnemyTakeDamage
{
    public int health { get; set; }

    public void TakeDamage(int DamageAmount)
    {
        health -= DamageAmount;
        if (health <= 0)
        {
            GameManager._instance.IncreaseScore(25);
            Destroy(this.gameObject);
        }
    }
}
