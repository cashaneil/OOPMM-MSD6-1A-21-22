using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public interface ITakeDamage
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
    Text killsText;
    Text healthText;
    Transform healthBar;

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

        DontDestroyOnLoad(this.gameObject);

        //When scene has loaded add functionality of OnSceneLoaded()
        SceneManager.sceneLoaded += OnSceneLoaded;

        //loading data
        GameData.Score = 0;
        GameData.HighScore = 0;
        GameData.Kills = 0;
        GameData.CurrentLevel = GameData._currentLevel.Level1;
        GetComponent<SaveLoadManager>().LoadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        //update UI score text with game data score at start
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        killsText = GameObject.Find("KillsText").GetComponent<Text>();
        scoreText.text = "Score: " + GameData.Score.ToString();
        killsText.text = "Kills: " + GameData.Kills.ToString();

        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        healthBar = GameObject.Find("PlayerHealthBar").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void IncreaseScoreandKills(int ScoreValue)
    {
        GameData.Score += ScoreValue;
        scoreText.text = "Score: " + GameData.Score.ToString();

        GameData.Kills++;
        killsText.text = "Kills: " + GameData.Kills.ToString();

        GetComponent<SaveLoadManager>().SaveData();

        //load next level if score conditions are met
        if (GameData.Score >= 250 && SceneManager.GetActiveScene().name == "Level1")
        {
            NextLevel();
        }
        else if (GameData.Score >= 450 && SceneManager.GetActiveScene().name == "Level2")
        {
            NextLevel();
        }
        else if (GameData.Score >= 650 && SceneManager.GetActiveScene().name == "Level3")
        {
            NextLevel();
        }
    }

    public void UpdateHealthText(int newHealthValue)
    {
        healthText.text = newHealthValue.ToString();
        Vector3 barLength = new Vector3((newHealthValue * healthBar.localScale.x) / 100, healthBar.localScale.y, healthBar.localScale.z);
        healthBar.localScale = barLength;
    }

    public void OnPlayerDie()
    {
        GetComponent<SaveLoadManager>().SaveData();
        SceneManager.LoadScene("GameOver");
    }

    public void NextLevel()
    {
        switch (GameData.CurrentLevel)
        {
            //check CURRENT level to determine whether to iterate to next level or go to win scene
            case GameData._currentLevel.Level1:
                GameData.CurrentLevel++;
                Debug.Log(GameData.CurrentLevel.ToString());
                GetComponent<SaveLoadManager>().SaveData(); //save data before loading scene
                SceneManager.LoadScene(GameData.CurrentLevel.ToString());
                break;

            case GameData._currentLevel.Level2:
                GameData.CurrentLevel++;
                GetComponent<SaveLoadManager>().SaveData();
                SceneManager.LoadScene(GameData.CurrentLevel.ToString());
                break;

            case GameData._currentLevel.Level3:
                GetComponent<SaveLoadManager>().SaveData();
                SceneManager.LoadScene("Win");
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level1" || scene.name == "Level2" || scene.name == "Level3")
        {
            //save data till this point
            GetComponent<SaveLoadManager>().SaveData();

            //update UI score text with game data score on scene load as well
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            killsText = GameObject.Find("KillsText").GetComponent<Text>();
            scoreText.text = "Score: " + GameData.Score.ToString();
            killsText.text = "Kills: " + GameData.Kills.ToString();

            healthText = GameObject.Find("HealthText").GetComponent<Text>();
            healthBar = GameObject.Find("PlayerHealthBar").transform;
        }

        if (scene.name == "Win" || scene.name == "GameOver")
        {
            GetComponent<SaveLoadManager>().SaveData();

            Text sceneScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            Text sceneKillsText = GameObject.Find("KillsText").GetComponent<Text>();
            Text sceneHighScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();
            Text sceneMessageText = GameObject.Find("MessageText").GetComponent<Text>();

            sceneScoreText.text = "Score: " + GameData.Score;
            sceneKillsText.text = "Kills: " + GameData.Kills;

            if (GameData.Score > GameData.HighScore)
            {
                GameData.HighScore = GameData.Score;
                sceneHighScoreText.text = "New High Score of " + GameData.HighScore + "!";
            }
            else
            {
                sceneHighScoreText.text = "High Score is still at " + GameData.HighScore + ". Think you can beat it again?";
            }

            if (GameData.Score >= 3000 && scene.name == "Win")
            {
                sceneMessageText.text = "You're a natural shooter!";
            }
            else if (GameData.Score < 3000 && scene.name == "Win")
            {
                sceneMessageText.text = "Great Job!";
            }
            else
            {
                sceneMessageText.text = "Better luck next time!";
            }

            //resetting game data
            GameData.Score = 0;
            GameData.Kills = 0;
            GameData.CurrentLevel = GameData._currentLevel.Level1;
            GetComponent<SaveLoadManager>().SaveData();
        }
    }

    //for testing
    void QuitGame()
    {
        GameData.Score = 0;
        GameData.Kills = 0;
        GameData.CurrentLevel = GameData._currentLevel.Level1;
        GetComponent<SaveLoadManager>().SaveData();

        UnityEditor.EditorApplication.isPlaying = false;
    }
}
