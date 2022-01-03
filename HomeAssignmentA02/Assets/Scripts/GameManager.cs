using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface EnemyTakeDamage
{
    int health { get; set; }

    void TakeDamage(int DamageAmount);
}

public class GameManager : MonoBehaviour
{
    //instance of GameManager which cannot be instantiated
    public static GameManager _instance;
    //added using UnityEngine.UI to recognise type Text
    Text scoreText;

    //to create instance of class at start before everything else
    //to ensure that only that 1 instance is kept and others are removed
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //update UI score text with game data score at start
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " + GameData.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int ScoreValue)
    {
        GameData.Score += ScoreValue;
        scoreText.text = "Score: " + GameData.Score.ToString();
    }
}
