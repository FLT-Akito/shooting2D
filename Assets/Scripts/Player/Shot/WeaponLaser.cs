using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : WeaponBase
{

    public EventInt shotEvent;
    private Vector3 plPosi;
    private float offsetX = 3.5f;
    public GameObject Player;

    public override void Shot()
    {
        shotEvent.Invoke(0);
       
    }

    public override void Fire()
    {
        //Debug.Log(this.gameObject.name);
        plPosi = Player.transform.position;
        plPosi.x += offsetX;
        PlayerBullet laserBullet = Instantiate(BulletPrefab, plPosi, Quaternion.identity).GetComponent<PlayerBullet>();
        laserBullet.Init(speed, direction);
       
    }
    //private void LaserShot()
    //{
    //    WeaponBase.LaserPrefab = Resources.Load<GameObject>("Laser");
    //    PlayerBullet laserBullet = Instantiate(WeaponBase.LaserPrefab, LaserShotPoint.position, Quaternion.identity).GetComponent<PlayerBullet>();
    //    laserBullet.Init(WeaponBase.speed, WeaponBase.direction);

    //}


}
