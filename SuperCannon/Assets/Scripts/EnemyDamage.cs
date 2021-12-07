using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour, ITakeDamage
{
    public int health { get; set; }

    public void TakeDamage(int damageamount)
    {
        health = health - damageamount;
        GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color + new Color(0.2f, 0f, 0f, -0.3f);
        GameManager._instance.IncreaseScore(1);
        if (health <= 0) Destroy(this.gameObject);
    }
    
    //public int health;
    //public void TakeDamage()
    //{
    //    health = health - damagetoapply;
    //    GameManager._instance.IncreaseScore(1);
    //    if (health <= 0) Destroy(this.gameObject);
    //}
}
