using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
