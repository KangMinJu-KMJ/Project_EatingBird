using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : EnemyMovement
{

    protected override void Start()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        base.originSpeed = 8;
        base._speed = base.originSpeed;
    }
}
