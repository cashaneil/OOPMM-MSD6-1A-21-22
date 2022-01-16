using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharTakeDamage : MonoBehaviour, ITakeDamage
{
    public int health { get; set; }

    public void TakeDamage(int DamageAmount)
    {
        health -= DamageAmount;
        if (gameObject.tag == "Player")
        {
            GameManager._instance.UpdateHealthText(health);
        }
        
        if (health <= 0)
        {
            //if player is taking damage
            if (gameObject.tag == "Player")
            {
                GameManager._instance.OnPlayerDie();
                Destroy(this.gameObject);
            }
            //if enemy is taking damage
            else if (gameObject.tag == "Enemy")
            {
                if (GameData.CurrentLevel == 1)
                {
                    GameManager._instance.IncreaseScoreandKills(25);
                }
                else if (GameData.CurrentLevel == 2)
                {
                    GameManager._instance.IncreaseScoreandKills(50);
                }
                else if (GameData.CurrentLevel == 3)
                {
                    GameManager._instance.IncreaseScoreandKills(100);
                }
                Destroy(this.gameObject);
            }
        }
    }
}
