using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Blast : Blast
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
        speed = 9f;
        base.BlastToTarget(targetPos);
    }
}
