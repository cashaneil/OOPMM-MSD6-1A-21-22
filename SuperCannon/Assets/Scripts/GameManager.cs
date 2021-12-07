using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ITakeDamage {
    int health { get; set; }
    void TakeDamage(int damageamount);
}

public class GameManager : MonoBehaviour
{
    //creating static (cannot be instantiated) instance of GameManager itself
    //this is so that we can make the instance to be created as soon as we start the game
    //this is because we inserted it in the Awake() method
    //to be able to make sure that an instance of this class is created in the start before anything else
    //is by creating the instance ourselves and inserting in the Awake() method
    public static GameManager _instance;
    //added 'using UnityEngine.UI;' to recognise 'Text' type
    [SerializeField] Text myscoreText;

    private void Awake()
    {
        //SINGLETON PATTERN - ensure you have only 1 instance of a class
        //We only want 1 GameManger to exist
        //so in case that others exist, delete them
        //To ensure that only 1 instance of GameManager is created
        //check if an instance(s) was already created
        //if _instance is empty, keep and store this instance of GameManager
        //else if it's not empty, destroy others trying to be stored
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
        //instead of using SerializeField to link the ScoreText game object and its Text component
        //we link it through code, by doing the following
        myscoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        //read score from GameData and update it to text at start
        myscoreText.text = GameData.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int scoreValue)
    {
        GameData.Score = GameData.Score + scoreValue;
        //alternative value: GameData.Score += scoreValue;
        Debug.Log("scoreValue: "+GameData.Score.ToString());
        //'.text' must be added as myscoreText has other components than text as can be seen from inspector
        myscoreText.text = "Score: " + GameData.Score.ToString();
    }
}
