using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Blast : Blast
{
    protected override void BlastToTarget(Vector3 targetPos)
    {
        speed = 8f;
        base.BlastToTarget(targetPos);
    }
}
