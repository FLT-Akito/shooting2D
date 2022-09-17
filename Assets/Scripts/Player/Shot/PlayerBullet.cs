using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
   // protected float missileSpeed;
    protected Vector3 _direction;
    protected float bulletSpeed = 20f;
    GameObject wallRight;
    Vector3 wrposi;

    private void Start()
    {
        wallRight = GameObject.Find("WallRight");
        wrposi = wallRight.transform.position;
      
    }

    void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * _direction);
        //transform.Translate(bulletSpeed * Time.deltaTime,0,0);
         //DoubleShot();
        // MissileShot();

        PlayerBulletBroken();
    }

     void PlayerBulletBroken()
    {
        if (this.transform.position.x >= wrposi.x)
        {
            Destroy(this.gameObject);
        }
    }
     
       public void Init(Vector3 position,float speed, Vector3 direction)
    {
        transform.position = position;
        this.bulletSpeed = speed;
        this._direction = direction.normalized;
        
    }

    public void Init(float speed, Vector3 _direction)
    {
        Init(transform.position, speed, _direction);
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            BulletDestroy(this.gameObject);
        }
           

    }

    protected virtual void BulletDestroy(GameObject bulletObj)
    {
        Destroy(bulletObj);
    }

}
