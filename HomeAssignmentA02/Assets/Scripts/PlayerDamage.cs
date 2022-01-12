using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour, ITakeDamage
{
    public int health { get; set; }

    public void TakeDamage(int DamageAmount)
    {
        health -= DamageAmount;
        Debug.Log(gameObject.tag + "'s new health is: " + health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
