using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonHandler : EnemyMovement
{
    [SerializeField]
    private float minScale = 0.5f;
    [SerializeField]
    private float maxScale = 1f;

    [SerializeField]
    private float scaleSpeed = 0.6f;

    private bool isSizeDown;
    private bool isSizeUp;

    //private bool isHitOutLine;

    protected override void Start()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        isSizeDown = true;
        isSizeUp = false;
        //isHitOutLine = false;
        base.Initialize();
    }

    protected override void FixedUpdate()
    {
        MoveEnemy();
    }

    protected override void MoveEnemy()
    {
        var _localScale = transform.localScale;

        if (isSizeDown)
        {
            _localScale.x += scaleSpeed * Time.deltaTime;
            _localScale.y -= scaleSpeed * Time.deltaTime;
            transform.localScale = _localScale;
            if (_localScale.x < minScale && _localScale.y < minScale)
            {
                isSizeDown = false;
                isSizeUp = true;
            }
        }
        else if (isSizeUp)
        {
            _localScale.x -= scaleSpeed * Time.deltaTime;
            _localScale.y += scaleSpeed * Time.deltaTime;
            transform.localScale = _localScale;
            if (_localScale.x < maxScale && _localScale.y > maxScale) //오늘의 주의점 : X혹은 Y값이 -가 되었을때 조건문 확인을 잘 하자
            {
                isSizeUp = false;
                isSizeDown = true;
            }
        }


        base.MoveEnemy();
    }
}
