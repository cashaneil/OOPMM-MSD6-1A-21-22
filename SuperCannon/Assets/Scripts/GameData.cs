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
    static float xMin, xMax, yMin, yMax;
    
    static Camera gameCamera = Camera.main;

    static private Vector3 mousepos = new Vector3();

    //specifying real world coordinate values corresponding to camera coordinates through methods
    
    public static void GetXMin()
    {
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
    }

    public static void GetXMax()
    {
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
    }
    
    public static void GetYMin()
    {
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y;
    }
    
    public static void GetYMax()
    {
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y;
    }

    //By switching from void to Vector3, method GetMouseTarget has become a sort of variable
    public static Vector3 GetMouseTarget()
    {
        //convert the mouse  position on screen to game units (world points) and store it in Vector3 mousepos
        mousepos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
        return mousepos;
    }
}
