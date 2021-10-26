using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //creating type GameObject to reference to ball prefab
    //ballPrefab game object will appear in unity and Ball prefab will be selected
    private GameObject ballPrefab;
    private float xMin, xMax, yMin, yMax;
    private Camera gameCamera;

    [SerializeField] float padding = 0;

    // Start is called before the first frame update
    void Start()
    {
        ballPrefab = Resources.Load("Circle") as GameObject;
        gameCamera = Camera.main;

        //specifying real world coordinate values corresponding to camera coordinates
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y;

        //0,0
        Instantiate(ballPrefab, new Vector3(xMin + padding, yMin + padding, 0f), Quaternion.identity);
        //1,0
        Instantiate(ballPrefab, new Vector3(xMax - padding, yMin + padding, 0f), Quaternion.identity);
        //0,1
        Instantiate(ballPrefab, new Vector3(xMin + padding, yMax - padding, 0f), Quaternion.identity);
        //1,1
        Instantiate(ballPrefab, new Vector3(xMax - padding, yMax - padding, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
