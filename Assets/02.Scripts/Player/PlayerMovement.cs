using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Transform playerTr;

    private float h = 0f, v = 0f;

    void Start()
    {
        Initialize();
    }

    
    void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if(rbody)
        {
            Vector3 Speed = rbody.velocity;//velocity : �ӵ�,���� ���� = ��
            Speed.x = 4 * h;
            Speed.y = 4 * v;
            rbody.velocity = Speed;

            //�÷��̾ ȭ������� ������ �ʰԲ� ����
            Vector3 pos = Camera.main.WorldToViewportPoint(playerTr.position);
            if (pos.x < 0.05f) pos.x = 0.05f;
            if (pos.x > 0.95f) pos.x = 0.95f;
            if (pos.y < 0.05f) pos.y = 0.05f;
            if (pos.y > 0.95f) pos.y = 0.95f;
            playerTr.position = Camera.main.ViewportToWorldPoint(pos);
        }
        
    }

    public void OnStickChanged(Vector2 stick)//���̽�ƽ�� ���� �޾ƿͼ� �̵�
    {
        h = stick.x;
        v = stick.y;
    }

    private void Initialize()
    {
        rbody = GetComponent<Rigidbody2D>();
        playerTr = GetComponent<Transform>();
    }
}
