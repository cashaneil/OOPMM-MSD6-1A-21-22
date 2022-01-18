using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : MonoBehaviour
{
    private static int _score;
    private static int _highScore;
    private static int _kills;
    public enum _currentLevel
    {
        Level1,
        Level2,
        Level3
    }

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

    public static _currentLevel CurrentLevel
    {
        get; set;
    }

    //specifying real world coordinate values corresponding to camera coordinates through methods
    public static float XMin
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x; }
    }

    public static float XMax
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x; }
    }

    public static float YMin
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y; }
    }

    public static float YMax
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y; }
    }

    public static Vector3 MousePos
    {
        get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); }
    }
}
