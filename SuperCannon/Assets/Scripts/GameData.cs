using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract means that no instances of the class my be created
//we should use the methods but not create instances of them
// A static method in C# is a method that keeps only one copy of the method at the Type level,
//not the object level. That means, all instances of the class share the same copy of the method and
//its data. The last updated value of the method is shared among all objects of that Type.
//ABSTRACT => NO INSTANCES CAN BE CREATED
//STATIC => VARIABLES/METHODS AT THE 'TYPE' LEVEL. - ONLY ONE
public abstract class GameData : MonoBehaviour
{
    static Camera gameCamera = Camera.main;
    static Vector3 mousepos = new Vector3();
    
    private static int _score = 0;
    public static int Score
    {
        set { _score = value; }
        get { return _score; }
    }

    //specifying real world coordinate values corresponding to camera coordinates through methods
    public static float XMin
    {
        get { return gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;}
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

    //public static float GetXMin()
    //{
    //    xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
    //    return xMin;
    //}

    //public static float GetXMax()
    //{
    //    xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
    //    return xMax;
    //}
    
    //public static float GetYMin()
    //{
    //    yMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y;
    //    return yMin;
    //}
    
    //public static float GetYMax()
    //{
    //    yMax = gameCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y;
    //    return yMax;
    //}

    //By switching from void to Vector3, method GetMouseTarget has become a sort of variable
    //public static Vector3 GetMouseTarget()
    //{
    //    //convert the mouse  position on screen to game units (world points) and store it in Vector3 mousepos
    //    mousepos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
    //    return mousepos;
    //}
}
