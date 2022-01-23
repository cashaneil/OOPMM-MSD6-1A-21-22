using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button StartButton, ViewhScoreButton, QuitButton, BackButton;
    [SerializeField] Text highScoreTitle, highScoreText;

    private void Awake()
    {
        //load saved data into game data to get high score if needed
        GetComponent<SaveLoadManager>().LoadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(StartGame);
        ViewhScoreButton.onClick.AddListener(ViewhScore);
        QuitButton.onClick.AddListener(QuitGame);
        BackButton.onClick.AddListener(BackFromViewHScore);

        highScoreText.text = GameData.HighScore.ToString();
    }

    void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    void ViewhScore()
    {
        //hide menu buttons
        StartButton.gameObject.SetActive(false);
        ViewhScoreButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);

        //show high score title and text
        highScoreTitle.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
    }

    void BackFromViewHScore()
    {
        //hide high score title and text
        highScoreTitle.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);

        //hide menu buttons
        StartButton.gameObject.SetActive(true);
        ViewhScoreButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
        #else
            Application.Quit();
        #endif
    }
}
