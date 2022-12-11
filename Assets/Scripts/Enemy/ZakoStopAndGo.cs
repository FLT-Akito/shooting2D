using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoStopAndGo : EnemyBase
{
    public Transform shotTransform;
    private Vector2 _direction = new Vector2(-1f, 1f);
    private Vector3 vec3PosXscale;
    public float angle;
    private int raydistance = 10;
    private float time;
    public float atkInterval;
    public float speedLate;
    public int maxAmmunitionCount;
    

    protected override void initialize()
    {
        attackEvent.AddListener(() =>
        {
            time = 0f;
        });

        vec3PosXscale = transform.localScale;

        ChangeState(new ZakoStopAndGo.Standby(this));
    }

    protected override Vector2 GetShotDirection()
    {
        return _direction * vec3PosXscale;
    }

    protected override Vector2 GetShotPosition()
    {
        return shotTransform.position;
    }

  
    private class Standby : StateBase<EnemyBase>
    {
        ZakoStopAndGo zako;
        public Standby(EnemyBase _machine) : base(_machine)
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
                zako.ChangeState(new ZakoStopAndGo.ChaseMoveLeft(zako));
            }
        }
    }

    private class ChaseMoveLeft : StateBase<EnemyBase>
    {
        ZakoStopAndGo zako;
        public ChaseMoveLeft(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            zako = (ZakoStopAndGo)machine;
        }

        public override void OnUpdate()
        {
            zako.time += Time.deltaTime;
           
            RaycastHit2D hit = Physics2D.Raycast(zako.shotTransform.position, zako._direction * zako.transform.localScale, zako.raydistance, Define.LAYER_PLAYER);

            if (hit)
            {
                zako.ChangeState(new ZakoStopAndGo.GoAttack(zako));
            }

            zako.transform.Translate((Vector2.left * zako.speedLate) * Time.deltaTime);

            if (Input.GetMouseButton(0))
            {
                Debug.DrawRay(zako.shotTransform.position, (zako._direction * zako.raydistance) * zako.transform.localScale, Color.green);
            }
        }
    }

    private class GoAttack : StateBase<EnemyBase>
    {
        ZakoStopAndGo zako;
        public GoAttack(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            zako = (ZakoStopAndGo)machine;
        }

        public override void OnUpdate()
        {
            zako.time += Time.deltaTime;

            if (zako.time > zako.atkInterval)
            {
                //zako.Attack();
                //zako.maxAmmunitionCount--;
            }

            if (zako.playerShip != null)
            {
                Vector3 dir = zako.playerShip.transform.position - zako.transform.position;
                zako.angle = Vector3.Angle(zako.transform.position, dir);
                //zako.angle = Mathf.Atan2(dir.y, dir.x);
            }

            RaycastHit2D hit = Physics2D.Raycast(zako.shotTransform.position, zako._direction * zako.transform.localScale, zako.raydistance, Define.LAYER_PLAYER);

            if (!hit)
            {
               
                if (zako.angle > 145)
                {
                    zako.ChangeState(new ZakoStopAndGo.ChaseMoveLeft(zako));
                }
                else
                {
                    zako.ChangeState(new ZakoStopAndGo.ChaseMoveRight(zako));
                }
            }

            if (Input.GetMouseButton(0))
            {
                Debug.DrawRay(zako.shotTransform.position, (zako._direction * zako.raydistance) * zako.transform.localScale, Color.green);
            }
        }
    }


    private class ChaseMoveRight : StateBase<EnemyBase>
    {
        ZakoStopAndGo zako;
        public ChaseMoveRight(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            zako = (ZakoStopAndGo)machine;
        }

        public override void OnUpdate()
        {
            zako.time += Time.deltaTime;

            if (zako.playerShip != null)
            {
                Vector3 dir = zako.playerShip.transform.position - zako.transform.position;
                zako.angle = Vector3.Angle(zako.transform.position, dir);
            }

            RaycastHit2D hit = Physics2D.Raycast(zako.shotTransform.position, zako._direction * zako.transform.localScale, zako.raydistance, Define.LAYER_PLAYER);

            if (hit)
            {
                zako.ChangeState(new ZakoStopAndGo.GoAttack(zako));
            }
            else if (hit == false && zako.maxAmmunitionCount <= 0)
            {
                zako.maxAmmunitionCount = 0;
                zako.ChangeState(new ZakoStopAndGo.Retreat(zako));
            }

            zako.transform.Translate((Vector2.right * zako.speedLate) * Time.deltaTime);

            if (Input.GetMouseButton(0))
            {
                Debug.DrawRay(zako.shotTransform.position, (zako._direction * zako.raydistance) * zako.transform.localScale, Color.green);
            }
        }
    }

    private class Retreat : StateBase<EnemyBase>
    {
        ZakoStopAndGo zako;

        public Retreat(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            zako = (ZakoStopAndGo)machine;
        }

        public override void OnUpdate()
        {
            zako.transform.Translate((Vector2.left  * zako.speedLate) * Time.deltaTime);
        }
    }


}



