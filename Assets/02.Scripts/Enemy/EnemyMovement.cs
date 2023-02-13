using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected float _speed; //적 개체의 현재 스피드
    protected float originSpeed = 4f;

    protected virtual void Start()
    {
        Initialize();
    }

    protected virtual void FixedUpdate()
    {
        MoveEnemy();
    }

    protected virtual void Initialize()
    {
        _speed = originSpeed;
    }

    protected virtual void MoveEnemy()
    {
        float xMove = 0f;
        xMove += _speed * Time.deltaTime;
        transform.position = new Vector3(-xMove, 0f, 0f);
    }
}
