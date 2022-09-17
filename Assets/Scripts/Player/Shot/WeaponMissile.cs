using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMissile : WeaponBase
{

    //public bool requestMissile;
    //public bool IsMissileRequest { get; set; }
    public EventInt shotEvent;

    public override void Shot()
    {
        // WeaponBase.MissilePrefab = Resources.Load<GameObject>("Missile");
        //var angle = Mathf.PI / 3.0f;
        //var _direction = new Vector3(Mathf.Cos(-angle), Mathf.Sin(-angle), 0);
        shotEvent.Invoke(0);
        //PlayerBullet missileBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<PlayerBullet>();
        //missileBullet.Init(speed, direction);
    }

    public override void Fire()
    {
        PlayerBullet missileBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<PlayerBullet>();
        missileBullet.Init(speed, direction);

    }


}
