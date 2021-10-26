using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesSpawner : MonoBehaviour
{
    private GameObject mysquareprefab;
    private GameObject mycircleprefab;
    
    // Start is called before the first frame update
    void Start()
    {
        mysquareprefab = Resources.Load("Square") as GameObject;
        mycircleprefab = Resources.Load("Circle") as GameObject;

        GameObject mysquare = Instantiate(mysquareprefab, new Vector3(0, -2f, 0), Quaternion.identity);
        GameObject mycircle = Instantiate(mycircleprefab, new Vector3(0, 2f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
