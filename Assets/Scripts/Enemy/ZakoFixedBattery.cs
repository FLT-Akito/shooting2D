using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoFixedBattery : EnemyBase
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
        if(IsCameraVeiw())
        {
            time += Time.deltaTime;

            if (time > atkInterval)
            {
                Attack();
            }
        }
    }

}
