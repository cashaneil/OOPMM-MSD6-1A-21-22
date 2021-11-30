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
        if (mycollider.gameObject.tag == "Bullet")  //if enemy collides with Game Object tagged as 'Bullet', destroy it
        {
            if (this.gameObject.name == "CircleEnemy(Clone)")
            {
                //calling the _instance GameManager game object instance we created in GameManager
                //to be able to call the IncreaseScore method In GameManager
                GameManager._instance.IncreaseScore(2);
                //alternatively, you can find the GameManager game object instance through the enemy instance
                //GameObject.Find("GameManagerHolder").GetComponent<GameManager>().IncreaseScore(5);
            }
            else if (this.gameObject.name == "DiamondEnemy(Clone)")
            {
                GameManager._instance.IncreaseScore(4);
            }
            else if (this.gameObject.name == "Enemy(Clone)")
            {
                GameManager._instance.IncreaseScore(6);
            }

            Debug.Log("New score is: " + GameData.Score.ToString()); //the adding to score should be before destroying the enemy, otherwise the enemy class is destroyed and the code stops before adding to the score

            Destroy(this.gameObject); //destroy the enemy
            Destroy(mycollider.gameObject); //destroy the bullet
        }

        if (mycollider.gameObject.tag == "Floor") //if enemy collides with Game Object tagged as 'Floor'(EnemyDestroyer), destroy it
        {
            Destroy(this.gameObject); //destroy the enemy
        }
    }
}
