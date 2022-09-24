using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zako3 : EnemyController
{
    /*
     * 問題点
     * wallRightがgameobjectと一致したときに
     * Move(),Attack()を呼びたいが、
     * クラスごとに毎回WallRightとgameobjectの判定をしないといけないのが面倒。
     * 毎回クールタイムの処理を書かないといけない
     * 
     * 対策
     * 
     */ 

    Vector2 position;
    Vector2 velocity = new Vector2(1f,0f);
    public float xPositionMax;
    public float xPositionMin;

    protected override void initialize()
    {
        position = transform.position;
    }

    private void Update()
    {
       
        Move();
    }

    protected override void Move()
    {
        
        position.x += velocity.x * Time.deltaTime;

        if(position.x > xPositionMax)
        {
            position.x = xPositionMax;
            velocity.x = -velocity.x;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if(position.x < xPositionMin)
        {
            position.x = xPositionMin;
            velocity.x = -velocity.x;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        transform.position = position;
    }
}
