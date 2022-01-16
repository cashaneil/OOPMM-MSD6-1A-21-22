using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : MonoBehaviour
{
    static Camera gameCamera = Camera.main;
    private static int _score;
    private static int _highScore;
    private static int _kills;
    private static int _currentLevel;

    public static int Score
    {
        set { _score = value; }
        get { return _score; }
    }

    public static int HighScore
    {
        get { return _highScore; }
        set { _highScore = value; }
    }

    public static int Kills
    {
        get { return _kills; }
        set { _kills = value; }
    }

    public static int CurrentLevel
    {
        get { return _currentLevel; }
        set { _currentLevel = value; }
    }

    //specifying real world coordinate values corresponding to camera coordinates through methods
    public static float XMin
    {
        get { return gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x; }
    }

    public static float XMax
    {
        get { return gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x; }
    }

    public static float YMin
    {
        get { return gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y; }
    }

    public static float YMax
    {
        get { return gameCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y; }
    }

    public static Vector3 MousePos
    {
        get { return gameCamera.ScreenToWorldPoint(Input.mousePosition); }
    }
}
