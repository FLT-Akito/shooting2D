using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoFixedBattery : EnemyController
{
    private float time;
    public float atkInterval;

    protected override void initialize()
    {
        attackEvent.AddListener(() =>
        {
            time = 0f;
        });
    }

    
    private void Update()
    {
        //if (isAttack)
        //{
        //    Attack();
        //}

        //if (wallRight.transform.position.x >= this.gameObject.transform.position.x)
        //{
           
        //    //isAttack = false;
            
        //}

        if(IsCameraVeiw())
        {
            time += Time.deltaTime;

            if (time > atkInterval)
            {
                Attack();
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
