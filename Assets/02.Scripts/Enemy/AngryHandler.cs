using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryHandler : EnemyMovement
{
    [Header("Y축 속도, 길이")]
    [SerializeField, Range(0f,10f)]
    protected float _ySpeed = 3f;

    [SerializeField, Range(0f, 10f)]
    protected float yLength = 2f;

    protected float xMove = 0f;
    protected float yMove = 0f;
    protected Vector3 xPos;
    protected Vector3 yPos;

    protected override void Start()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        yPos = transform.position;
        xPos = transform.position;
    }

    protected override void FixedUpdate()
    {
        MoveEnemy();
    }

    protected override void MoveEnemy()
    {
        xMove = -(_speed * Time.deltaTime);
        xPos.x += xMove;

        yMove += Time.deltaTime * _ySpeed;
        yPos.y = Mathf.Sin(yMove) * yLength;

        transform.position = xPos + yPos;

    }
}
