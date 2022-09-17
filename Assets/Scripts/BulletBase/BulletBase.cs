using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    protected float speed;
    protected Vector2 direction;
    GameObject limit_WallLeft;



    private void Start()
    {
        limit_WallLeft = GameObject.Find("WallLeft");
    }

    public void Init(Vector3 _position, float _speed, Vector2 _direction)
    {
        transform.position = _position;
        this.speed = _speed;
        this.direction = _direction.normalized;
        //�P�ʕ����x�N�g��:���������ق�������傫���𐳋K�����Ă�����
       
    }

    public void Init(float _speed, Vector2 _direction)
    {
        Init(transform.position, _speed, _direction);
    }

    

    public void EnemyBulletBroken(GameObject wallLeft)
    {
        if (this.gameObject.transform.position.x < wallLeft.transform.position.x)
            Destroy(this.gameObject);

    }

    void Update()
    {
        //�X�J���[�{(speed): �x�N�g��ka(direction:�P�ʃx�N�g��) speed * direction
        transform.Translate(direction * speed * Time.deltaTime); 
        EnemyBulletBroken(limit_WallLeft);
        
    }
}
