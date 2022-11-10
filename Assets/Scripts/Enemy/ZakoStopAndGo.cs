using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoStopAndGo : EnemyController
{
    private Vector2 _direction = new Vector2(-1f ,1f);
    private Ray2D ray;
    public int raydistance = 10;
    private float time;
    public float atkInterval;

    public enum DIRECTION_TYPE
    {
        STOP,
        LEFT,
        RIGHT
    }

    DIRECTION_TYPE directionType = DIRECTION_TYPE.STOP;
    
    protected override void initialize()
    {
        attackEvent.AddListener(() =>
        {
            time = 0f;
        });

        transform.position = _direction;
        ray = new Ray2D(transform.position, _direction);
        //Debug.Log(LayerMask.LayerToName(Define.LAYER_PLAYER));
    }

    void Update()
    {
        //Debug.DrawLine(transform.position, new Vector3(-0.3f, 0.3f, 0));
        //Debug.DrawRay(transform.position, new Vector3(0, 0, 100f), Color.red);
        if (IsCameraVeiw())
        {
            time += Time.deltaTime;
            RaycastHit2D hit = Physics2D.Raycast(transform.position = ray.origin, (ray.direction * raydistance) * transform.localScale, raydistance,Define.LAYER_PLAYER);
            //Debug.Log(hit.collider);
            if(hit.collider == false)
            {
                directionType = DIRECTION_TYPE.LEFT;
                
            }
            else
            {
                directionType = DIRECTION_TYPE.STOP;
            }
            
            switch(directionType)
            {
                case DIRECTION_TYPE.STOP:
                    if (hit.collider && time > atkInterval)
                    {
                        Attack();
                    }

                    break;
                case DIRECTION_TYPE.LEFT:
                    this.transform.Translate(Vector2.left * 1.0f * Time.deltaTime);
                    break;
                case DIRECTION_TYPE.RIGHT:
                    this.transform.Translate(Vector2.right * 1.0f * Time.deltaTime);
                    break;
            }
           
        }
        if (Input.GetMouseButton(0))
        {
            Debug.DrawRay(ray.origin, (ray.direction * raydistance) * transform.localScale, Color.green);
            //Debug.Log(LayerMask.LayerToName(layermask));
            //RaycastHit2D hit = Physics2D.Raycast(ray.origin, (ray.direction * transform.localScale), raydistance, Define.LAYER_PLAYER);

            //if (hit.collider)
            //{
            //    Debug.Log(hit.collider.gameObject.name);
            //}
        }
    }

    protected override Vector2 Direction()
    {
        return _direction;
    }

}
