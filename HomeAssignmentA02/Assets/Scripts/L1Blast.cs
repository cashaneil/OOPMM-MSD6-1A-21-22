using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Blast : Blast
{
    // Start is called before the first frame update
    protected override void Start()
    {
        speed = 7f;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
