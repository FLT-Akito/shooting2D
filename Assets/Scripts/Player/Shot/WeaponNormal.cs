using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class WeaponNormal : WeaponBase
{
    //public UnityEvent shotEvent;
    public EventInt shotEvent;

    public override void Shot()
    {
       shotEvent.Invoke(0);
        
    }

    public override void Fire()
    {
        PlayerBullet playerbullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<PlayerBullet>();
        playerbullet.Init(speed, direction);
    }

}
