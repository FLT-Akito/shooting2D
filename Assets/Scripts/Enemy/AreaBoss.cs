using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SPATTACKTYPE
{
    CIRCLE = 0,
    EIGHTWAY,
    THREEWAY
}

public class AreaBoss : EnemyBase
{
    private float speed = 3f;
    public GameObject spBulletPref;
    public Transform bulletPosition;

    protected override void initialize()
    {
        ChangeState(new AreaBoss.MoveUp(this));
    }

    protected override void Attack()
    {
        float offsetX = 1f;
        float offsetY = 1.5f;
        Vector3 myselfBulletPosi = bulletPosition.position;

        Instantiate(enemyBulletPref, bulletPosition.position, Quaternion.Euler(0f, 0f, -90f));

        for(int i = 1; i < 2; i++)
        {
            Vector3 targetPosiUp = new Vector3(myselfBulletPosi.x + (i * offsetX),
                     myselfBulletPosi.y + (i * offsetY));

            Vector3 targetPosiDown = new Vector3(myselfBulletPosi.x + (i * offsetX),
                     myselfBulletPosi.y + (i * -offsetY));

            Instantiate(enemyBulletPref, targetPosiUp, Quaternion.Euler(0f, 0f, -90f));
            Instantiate(enemyBulletPref, targetPosiDown, Quaternion.Euler(0f, 0f, -90f));
        }
    }

    private void SpAttack(SPATTACKTYPE spAttackType)
    {
        switch(spAttackType)
        {
            case SPATTACKTYPE.CIRCLE:
                Debug.Log("CIRCLE");
                break;

            case SPATTACKTYPE.EIGHTWAY:
                Debug.Log("EIGHTWAY");
                break;

            case SPATTACKTYPE.THREEWAY:
                Debug.Log("THREEWAY");
                break;
        }
    }

    private class MoveUp : StateBase<EnemyBase>
    {
        private AreaBoss boss;
        public MoveUp(AreaBoss _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            boss = (AreaBoss)machine;
        }

        public override void OnUpdate()
        {
            boss.transform.Translate(Vector2.left * boss.speed * Time.deltaTime);
            if(boss.transform.position.y > 3.3f)
            {
                boss.ChangeState(new AreaBoss.NomalAttack(boss));
            }
        }
    }

    private class NomalAttack : StateBase<EnemyBase>
    {
        AreaBoss boss;
        public NomalAttack(AreaBoss _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            boss = (AreaBoss)machine;
        }

        public override void OnUpdate()
        {
            boss.Attack();

            if(boss.transform.position.y >= 3.3f)
            {
                boss.ChangeState(new AreaBoss.MoveDown(boss));
            }

            if(boss.transform.position.y <= -3.3f)
            {
                boss.ChangeState(new AreaBoss.MoveCenter(boss));
            }
            
        }
    }

    private class MoveDown : StateBase<EnemyBase>
    {
        AreaBoss boss;
        public MoveDown(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            boss = (AreaBoss)machine;
        }

        public override void OnUpdate()
        {
            boss.transform.Translate(Vector2.right * boss.speed * Time.deltaTime);
            if(boss.transform.position.y < -3.3f)
            {
                boss.ChangeState(new AreaBoss.NomalAttack(boss));
            }
        }
    }

    private class MoveCenter : StateBase<EnemyBase>
    {
        AreaBoss boss;
        public MoveCenter(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            boss = (AreaBoss)machine;
        }

        public override void OnUpdate()
        {
            boss.transform.Translate(Vector2.left * boss.speed * Time.deltaTime);
            if(boss.transform.position.y > 0)
            {
                boss.ChangeState(new AreaBoss.SpecialAttack(boss));
            }

        }
    }

    private class SpecialAttack : StateBase<EnemyBase>
    {
        AreaBoss boss;
        private int randomSpAttack;
        public SpecialAttack(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            boss = (AreaBoss)machine;
            randomSpAttack = Random.Range(0, 3);
        }

        public override void OnUpdate()
        {
            boss.SpAttack((SPATTACKTYPE)randomSpAttack);
            boss.ChangeState(new AreaBoss.MoveUp(boss));
        }
    }
}
