using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zako3 : EnemyBase
{
    private Vector2 position;
    private Vector2 velocity = new Vector2(2.5f, 0f);
    private float time;
    public float xPositionMax;
    public float xPositionMin;
    public float atkInterval;

    protected override void initialize()
    {
        position = transform.position;
        attackEvent.AddListener(() =>
        {
            time = 0f;
        });
    }

    private void Update()
    {
        Move();

        if (IsCameraVeiw())
        {
            time += Time.deltaTime;

            if (time > atkInterval)
            {
                Attack();
            }
        }
    }

    protected override void Move()
    {

        position.x += velocity.x * Time.deltaTime;

        if (position.x > xPositionMax)
        {
            position.x = xPositionMax;
            velocity.x = -velocity.x;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (position.x < xPositionMin)
        {
            position.x = xPositionMin;
            velocity.x = -velocity.x;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        transform.position = position;
    }
}
