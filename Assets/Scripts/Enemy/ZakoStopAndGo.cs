using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoStopAndGo : EnemyBase
{
    public Transform shotTransform;
    private Vector2 _direction = new Vector2(-1f, 1f);
    private Vector3 vec3PosXscale;
    private Vector2 VecDir;
    public float angle;
    public int raydistance = 10;
    private float time;
    private float speed = 1f;
    public float atkInterval;

    //private Dictionary<string, Vector3> posScaleX = new Dictionary<string, Vector3>()
    //{
    //    ["left"] = new Vector3(-1f, 1f, 1f),
    //    ["right"] = new Vector3(1f, 1f, 1f)
    //};

    public enum DIRECTION_TYPE
    {
        STOP,
        ATTACK,
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

        vec3PosXscale = transform.localScale;
        // ray = new Ray2D(transform.position, _direction);
        //Debug.Log(LayerMask.LayerToName(Define.LAYER_PLAYER));
        ChangeState(new ZakoStopAndGo.Test(this));
    }


    void Update1()
    {
        //Debug.DrawLine(transform.position, new Vector3(-0.3f, 0.3f, 0));
        //Debug.DrawRay(transform.position, new Vector3(0, 0, 100f), Color.red);
        if (IsCameraVeiw())
        {
            
            time += Time.deltaTime;
            if (playerShip != null)
            {
               
                Vector3 dir = playerShip.transform.position - shotTransform.position;
                angle = Vector3.Angle(this.transform.position, dir);
            }

            RaycastHit2D hit = Physics2D.Raycast(shotTransform.position, _direction * transform.localScale, raydistance, Define.LAYER_PLAYER);


            if (angle > 135)
            {
                
                directionType = DIRECTION_TYPE.LEFT;
            }
            else
            {
               
                directionType = DIRECTION_TYPE.RIGHT;
            }

            if (angle > 90)
            {
                vec3PosXscale.x = 1f;

            }
            else
            {
                vec3PosXscale.x = -1f;

            }

            transform.localScale = vec3PosXscale;

            if (hit)
            {
                directionType = DIRECTION_TYPE.ATTACK;
            }

            //if (playerShip != null)
            //{
            //    if (this.transform.position.x > playerShip.transform.position.x)
            //    {
            //        directionType = DIRECTION_TYPE.LEFT;
            //        vec3PosXscale.x = 1f;

            //    }
            //    if (this.transform.position.x < playerShip.transform.position.x)
            //    {
            //        directionType = DIRECTION_TYPE.RIGHT;
            //        //vec3PosXscale.x = -1f;
            //    }

            //   // transform.localScale = vec3PosXscale;
            //}

            //if (hit.collider)
            //{
            //    directionType = DIRECTION_TYPE.ATTACK;

            //}

            switch (directionType)
            {
                case DIRECTION_TYPE.STOP:
                    break;

                case DIRECTION_TYPE.ATTACK:
                    if (time > atkInterval)
                    {
                        Attack();
                    }
                    break;

                case DIRECTION_TYPE.LEFT:
                    this.transform.Translate(Vector2.left * speed * Time.deltaTime);
                    break;

                case DIRECTION_TYPE.RIGHT:
                    this.transform.Translate(Vector2.right * speed * Time.deltaTime);
                    break;
            }

        }

        if (Input.GetMouseButton(0))
        {
            Debug.DrawRay(shotTransform.position, (_direction * raydistance) * transform.localScale, Color.green);
            //Debug.Log(LayerMask.LayerToName(layermask));
            //RaycastHit2D hit = Physics2D.Raycast(ray.origin, (ray.direction * transform.localScale), raydistance, Define.LAYER_PLAYER);

            //if (hit.collider)
            //{
            //    Debug.Log(hit.collider.gameObject.name);
            //}
        }
    }

    protected override Vector2 GetShotDirection()
    {
        return _direction * vec3PosXscale;
    }

    protected override Vector2 GetShotPosition()
    {
        return shotTransform.position;
    }

    private class Test : StateBase<EnemyBase>
    {
        ZakoStopAndGo zako;
        public Test(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            zako = (ZakoStopAndGo)machine;
        }
        public override void OnUpdate()
        {
            if (zako.IsCameraVeiw())
            {

                zako.time += Time.deltaTime;
                if (zako.playerShip != null)
                {

                    Vector3 dir = zako.playerShip.transform.position - zako.shotTransform.position;
                    zako.angle = Vector3.Angle(zako.transform.position, dir);
                }

                RaycastHit2D hit = Physics2D.Raycast(zako.shotTransform.position, zako._direction * zako.transform.localScale, zako.raydistance, Define.LAYER_PLAYER);


                if (zako.angle > 135)
                {

                    zako.directionType = DIRECTION_TYPE.LEFT;
                }
                else
                {

                    zako.directionType = DIRECTION_TYPE.RIGHT;
                }

                if (zako.angle > 90)
                {
                    zako.vec3PosXscale.x = 1f;

                }
                else
                {
                    zako.vec3PosXscale.x = -1f;

                }

                zako.transform.localScale = zako.vec3PosXscale;

                if (hit)
                {
                    zako.directionType = DIRECTION_TYPE.ATTACK;
                }


                switch (zako.directionType)
                {
                    case DIRECTION_TYPE.STOP:
                        break;

                    case DIRECTION_TYPE.ATTACK:
                        if (zako.time > zako.atkInterval)
                        {
                            zako.Attack();
                        }
                        break;

                    case DIRECTION_TYPE.LEFT:
                        zako.transform.Translate(Vector2.left * zako.speed * Time.deltaTime);
                        break;

                    case DIRECTION_TYPE.RIGHT:
                        zako.transform.Translate(Vector2.right * zako.speed * Time.deltaTime);
                        break;
                }

            }
        }
    }
}



