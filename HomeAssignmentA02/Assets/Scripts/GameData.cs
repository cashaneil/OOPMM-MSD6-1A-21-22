using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : MonoBehaviour
{
    static Camera gameCamera = Camera.main;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
