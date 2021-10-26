using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ballPrefab = Resources.Load("Circle") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
