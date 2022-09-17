using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoFixedBatteryBase : EnemyController
{

    private float time;
    public int atkTime;

    protected override void initiarise()
    {
        attackEvent.AddListener(() =>
        {
            Debug.Log("listener");
            time = 0f;
        });
    }
    protected override void OnUpdate()
    {
       // Debug.Log(time);
        time += Time.deltaTime;
        if (time > atkTime)
        {
            //OnAttack();
            Attack_Triger = true;
            //time = 0;
        }

    }

    protected override void OnAttack()
    {
        
        Attack();
    }
    protected override void Move() { }
}
