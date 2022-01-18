using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3Blast : Blast
{
    protected override void BlastToTarget(Vector3 targetPos)
    {
        speed = 10f;
        base.BlastToTarget(targetPos);
    }
}
