using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDouble : WeaponBase
{
    public Vector2 direction2;

    public override void Shot()
    {
        PlayerBullet playerbullet1 = Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<PlayerBullet>();
        PlayerBullet playerbullet2 = Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<PlayerBullet>();
        playerbullet1.Init(speed, direction);
        playerbullet2.Init(speed, direction2);
    }
}
