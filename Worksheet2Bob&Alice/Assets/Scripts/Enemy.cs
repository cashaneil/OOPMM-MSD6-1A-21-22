using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitpoints, damage;
    string name;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Enemy constructor
    public Enemy(int hp, int dmg, string ID)
    {
        //this constructor assigns hitpoints, damage, and names
        //to the values passed into the constructor.
        hitpoints = hp;
        damage = dmg;
        name = ID;
    }

    public void TakeDamage()
    {
        hitpoints--; //reduce HP by 1
        Debug.Log(name + "'s HP: " + hitpoints); //print out new HP
    }

    public void Die()
    {
        Debug.Log(name + " Has Died"); //print to the console
    }
}
