using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Blast : Blast
{
    protected override void BlastToTarget(Vector3 targetPos)
    {
        speed = 6f;
        base.BlastToTarget(targetPos);
    }
}
