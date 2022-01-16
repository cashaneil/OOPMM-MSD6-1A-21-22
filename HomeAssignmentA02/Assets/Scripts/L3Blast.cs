using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3Blast : Blast
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void BlastToTarget(Vector3 targetPos)
    {
        speed = 12f;
        base.BlastToTarget(targetPos);
    }
}
