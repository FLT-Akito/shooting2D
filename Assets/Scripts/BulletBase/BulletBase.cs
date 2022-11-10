using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    protected float speed;
    protected Vector2 direction;
    
    public void Init(Vector3 _position, float _speed, Vector2 _direction)
    {
        transform.position = _position;
        this.speed = _speed;
        this.direction = _direction.normalized;
        //単位方向ベクトル:方向だけほしいから大きさを正規化してあげる
       
    }

    public void Init(float _speed, Vector2 _direction)
    {
        Init(transform.position, _speed, _direction);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DeadLine"))
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        //スカラー倍(speed): ベクトルka(direction:単位ベクトル) speed * direction
        transform.Translate(direction * speed * Time.deltaTime); 
        //EnemyBulletBroken(limit_WallLeft);
        
    }
}
