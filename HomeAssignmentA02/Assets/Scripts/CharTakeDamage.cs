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
                switch (GameData.CurrentLevel)
                {
                    case GameData._currentLevel.Level1:
                        GameManager._instance.IncreaseScoreandKills(25);
                        break;

                    case GameData._currentLevel.Level2:
                        GameManager._instance.IncreaseScoreandKills(50);
                        break;

                    case GameData._currentLevel.Level3:
                        GameManager._instance.IncreaseScoreandKills(100);
                        break;
                }

                Destroy(this.gameObject);
            }
        }
    }
}
