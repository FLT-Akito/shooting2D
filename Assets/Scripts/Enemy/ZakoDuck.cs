using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoDuck : EnemyBase
{
    public Transform shotTransform;
    private Vector2 _direction = new Vector2(1f, -1f);
    private Vector3 vec3PosXscale;
    public float angle;
    private int raydistance = 10;
    private float time;
    private float speed = 1f;
    public float atkInterval;
    public float speedLate;
    public int maxAmmunitionCount;

    protected override void initialize()
    {
        
            ChangeState(new ZakoDuck.Standby(this));
        
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
        ZakoDuck duck;
        public Standby(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            duck = (ZakoDuck)machine;
            Debug.Log("Standby");
        }

        public override void OnUpdate()
        {
            if(duck.IsCameraVeiw())
            {
                duck.gameObject.SetActive(true);
                duck.ChangeState(new ZakoDuck.ChaseMoveRight(duck));
            }
        }
    }

    private class ChaseMoveRight : StateBase<EnemyBase>
    {
        ZakoDuck duck;

        public ChaseMoveRight(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            duck = (ZakoDuck)machine;
        }

        public override void OnUpdate()
        {
            duck.time += Time.deltaTime;

            if (duck.playerShip != null)
            {
                Vector3 dir = duck.playerShip.transform.position - duck.shotTransform.position;
            }

            RaycastHit2D hit = Physics2D.Raycast(duck.shotTransform.position, duck._direction * duck.transform.localScale, duck.raydistance, Define.LAYER_PLAYER);

            if (hit)
            {
                duck.ChangeState(new ZakoDuck.GoAttack(duck));
            }

            duck.transform.Translate((Vector2.right * duck.speed * duck.speedLate) * Time.deltaTime);

            if (Input.GetMouseButton(0))
            {
                Debug.DrawRay(duck.shotTransform.position, (duck._direction * duck.raydistance) * duck.transform.localScale, Color.green);
            }
        }
    }

    private class GoAttack : StateBase<EnemyBase>
    {
        ZakoDuck duck;

        public GoAttack(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            duck = (ZakoDuck)machine;
        }

        public override void OnUpdate()
        {
            duck.time += Time.deltaTime;

            if (duck.time > duck.atkInterval)
            {
                duck.Attack();
                duck.maxAmmunitionCount--;
            }

            if (duck.playerShip != null)
            {
                Vector3 dir = duck.playerShip.transform.position - duck.shotTransform.position;
                duck.angle = Vector3.Angle(duck.transform.position, dir);
            }

            RaycastHit2D hit = Physics2D.Raycast(duck.shotTransform.position, duck._direction * duck.transform.localScale, duck.raydistance, Define.LAYER_PLAYER);

            if (!hit)
            {
                if (duck.angle > 45)
                {
                    duck.ChangeState(new ZakoDuck.ChaseMoveLeft(duck));
                }
                else
                {
                    duck.ChangeState(new ZakoDuck.ChaseMoveRight(duck));
                }
            }

            if (Input.GetMouseButton(0))
            {
                Debug.DrawRay(duck.shotTransform.position, (duck._direction * duck.raydistance) * duck.transform.localScale, Color.green);
            }
        }
    }

    private class ChaseMoveLeft : StateBase<EnemyBase>
    {
        ZakoDuck duck;

        public ChaseMoveLeft(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            duck = (ZakoDuck)machine;
        }

        public override void OnUpdate()
        {
            duck.time += Time.deltaTime;

            if (duck.playerShip != null)
            {
                Vector3 dir = duck.playerShip.transform.position - duck.shotTransform.position;
                duck.angle = Vector3.Angle(duck.transform.position, dir);
            }

            RaycastHit2D hit = Physics2D.Raycast(duck.shotTransform.position, duck._direction * duck.transform.localScale, duck.raydistance, Define.LAYER_PLAYER);

            if (hit)
            {
                duck.ChangeState(new ZakoDuck.GoAttack(duck));
            }
            else if (hit == false && duck.maxAmmunitionCount <= 0)
            {
                duck.ChangeState(new ZakoDuck.Retreat(duck));
            }

            duck.transform.Translate((Vector2.left * duck.speed * duck.speedLate) * Time.deltaTime);

            if (Input.GetMouseButton(0))
            {
                Debug.DrawRay(duck.shotTransform.position, (duck._direction * duck.raydistance) * duck.transform.localScale, Color.green);
            }
        }
    }

    private class Retreat : StateBase<EnemyBase>
    {
        ZakoDuck duck;

        public Retreat(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            duck = (ZakoDuck)machine;
        }

        public override void OnUpdate()
        {
            duck.transform.Translate((Vector2.left * duck.speed * duck.speedLate) * Time.deltaTime);
        }
    }
}
