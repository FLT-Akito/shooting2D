using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoFixedBattery : EnemyController
{
    /*
     * やりたいこと
     * 一定時間ごとに攻撃をする
     * 
     * どうすれば実現できるか
     * Attack()メソッドを一定の時間が経過したら呼び出す
     */
    private float time;
    private bool isAttack = true;
    public float atkTime;

    private GameObject wallRight;
    

    protected override void initialize()
    {
        wallRight = GameObject.Find("WallRight");
        attackEvent.AddListener(() =>
        {
            //Debug.Log("listener");
            time = 0f;
        });
     
    }

    
    private void Update()
    {
        if (isAttack)
        {
            Attack();
        }

        if (wallRight.transform.position.x >= this.gameObject.transform.position.x)
        {
           
            isAttack = false;
            time += Time.deltaTime;

            if (time > atkTime)
            {
                Attack();
                //OnAttack();
                Attack_Triger = true;
                //time = 0;
            }
        }
    }
   
    //protected override void OnUpdate()
    //{
    //   // Debug.Log(time);
    //    time += Time.deltaTime;
    //    if (time > atkTime)
    //    {
    //        //OnAttack();
    //        Attack_Triger = true;
    //        //time = 0;
    //    }

    //}

}
