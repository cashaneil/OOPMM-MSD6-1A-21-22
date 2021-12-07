using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour, ITakeDamage
{
    public int health { get; set; }

    public void TakeDamage(int damageamount)
    {
        GameManager._instance.IncreaseScore(1);
        Destroy(this.gameObject);
    }
}
