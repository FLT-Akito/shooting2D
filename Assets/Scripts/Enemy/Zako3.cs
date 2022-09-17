using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zako3 : EnemyController
{
    //Vector3 basePosition;
    //Vector3 v3Velocity;
    //float limitPosition_left = 85;
    //float limitPosition_right = 99;
    //bool onGround = false;
    //bool onWall = false;
   // LayerMask groundLayer;
    public float zako3_r1 = 7.0f;
    public float wallRight_r2 = 7.0f;
    //GameObject limit_WallLeft;
    //GameObject limit_WallRight;
    //GameObject player;
    public GameObject creatItem;

    /*
    void Update()
    {
       // Debug.Log(WallDistance(limit_WallRight.transform.position));
        //Debug.Log(limit_WallLeft.transform.position.x);
        //Debug.Log(limit_WallRight.transform.position.x + this.transform.position.x);

        //zako3_r1 = this.gameObject.transform.position.x / 2f;
        //wallRight_r2 = limit_WallLeft.transform.position.x / 2f;
        //if (WallDistance(limit_WallRight.transform.position) < zako3_r1 + wallRight_r2 )
        //{
        //    Debug.Log("‹ß‚Ã‚¢‚Ä‚¢‚é‚æ");
        //    Move(this.gameObject, limit_WallLeft);
        //    Attack(this.gameObject, player, EnemyBullet);
        //}


        //onGround = Physics2D.Linecast(transform.position,
        //                              transform.position - (transform.up * 0.1f),
        //                              groundLayer);

        //onWall = Physics2D.Linecast(transform.position,
        //                             transform.position + (transform.right * 0.1f),
        //                             groundLayer);


    }
    */

    public float WallDistance(Vector3 wallRight)
    {
        var zako3_p1 = this.transform.position;
        var _wallRight_p2 = wallRight;
        var dir = zako3_p1 - _wallRight_p2;
        var d = dir.magnitude;
        //var d = Vector3.Distance(zako3_p1, _wallRight_p2);

        return d;
    }

    protected override void Move() { }
  
}
