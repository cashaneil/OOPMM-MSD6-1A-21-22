using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeBullet : Bullet
{
    // Start is called before the first frame update
    protected override void Start()
    {
        speed = 5f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
