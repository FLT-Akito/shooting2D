using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public enum SPAttackType
{
    CIRCLE = 0,
    PLAYERAIM
}

public class AreaBoss : EnemyBase
{
    public UnityEvent destroyed = new UnityEvent();

    private float speed = 5f;

    public BulletBoss spBulletPref;
    public Transform bulletPosition;

    private SpriteRenderer bossImageColor;
    private float duration = 0.1f;
    private float period = 0.4f;
    private int repetition = 8;

    public MovingCamera _camera;

    protected override void initialize()
    {
        bossImageColor = GetComponent<SpriteRenderer>();
        ChangeState(new AreaBoss.Stanby(this));
    }

    protected override void Attack()
    {
        float offsetX = 1f;
        float offsetY = 1.5f;
        Vector3 myselfBulletPosi = bulletPosition.position;

        SetShot(enemyBulletPref.GetComponent<BulletBoss>(), myselfBulletPosi, Mathf.PI);

        for (int i = 1; i < 2; i++)
        {
            Vector3 targetPosiUp = new Vector3(myselfBulletPosi.x + (i * offsetX),
                     myselfBulletPosi.y + (i * offsetY));

            Vector3 targetPosiDown = new Vector3(myselfBulletPosi.x + (i * offsetX),
                     myselfBulletPosi.y + (i * -offsetY));

            SetShot(enemyBulletPref.GetComponent<BulletBoss>(), targetPosiUp, Mathf.PI);
            SetShot(enemyBulletPref.GetComponent<BulletBoss>(), targetPosiDown, Mathf.PI);
        }
    }

    protected override void DamageColor()
    {
        Sequence _seq;
        _seq = DOTween.Sequence();
        _seq.Append(bossImageColor.DOColor(Color.red, duration).SetEase(Ease.OutFlash, repetition, period));
        _seq.Append(bossImageColor.DOColor(Color.white, duration).SetEase(Ease.OutFlash, repetition, period));
        _seq.Play();
    }

    private void SetShot(BulletBoss bullet, Vector3 instacePosi, float angle)
    {
        BulletBoss _bullet = Instantiate(bullet, instacePosi, transform.rotation);
        _bullet.SetBulletAngle(angle);
    }

    private void SPShotN(int count)
    {
        int bulletCount = count;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            SetShot(spBulletPref, bulletPosition.position, angle);
        }
    }

    private void PlayerAimShot(int count)
    {
        if (playerShip != null)
        {
            Vector3 diffPosition = playerShip.transform.position - transform.position;

            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);
            int bulletCount = count;

            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - (bulletCount / 2f)) * ((Mathf.PI / 2f) / bulletCount);
                SetShot(spBulletPref, bulletPosition.position, angleP + angle);
            }
        }
    }

    IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            PlayerAimShot(m);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator WaveNShotDirectionM(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            SPShotN(m);
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void SpAttack(SPAttackType spAttackType)
    {
        switch (spAttackType)
        {
            case SPAttackType.CIRCLE:
                StartCoroutine(WaveNShotDirectionM(4, 16));
                break;

            case SPAttackType.PLAYERAIM:
                StartCoroutine(WaveNPlayerAimShot(4, 6));
                break;
        }
    }

    private void OnDestroy()
    {
        destroyed.Invoke();
    }

    private class Stanby : StateBase<EnemyBase>
    {
        AreaBoss boss;
        private bool isApeare = false;

        public Stanby(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            boss = (AreaBoss)machine;
            boss._camera.isCameraStop.AddListener(() =>
            {
                isApeare = true;
            });

            Debug.Log("Stanby");
        }

        public override void OnUpdate()
        {
          
            if (isApeare)
            {
                boss.transform.position += new Vector3(-3f * Time.deltaTime, 0f, 0f);

                if (boss.transform.position.x < 230f)
                {
                    boss.ChangeState(new AreaBoss.MoveUp(boss));
                }
            }
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

            if (boss.transform.position.y > 3.3f)
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

            if (boss.transform.position.y >= 3.3f)
            {
                boss.ChangeState(new AreaBoss.MoveDown(boss));
            }

            if (boss.transform.position.y <= -3.3f)
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

            if (boss.transform.position.y < -3.3f)
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

            if (boss.transform.position.y > 0)
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
            randomSpAttack = Random.Range(0, 2);
        }

        public override void OnUpdate()
        {
            boss.SpAttack((SPAttackType)randomSpAttack);
            boss.ChangeState(new AreaBoss.Stop(boss));
        }
    }

    private class Stop : StateBase<EnemyBase>
    {
        AreaBoss boss;
        private float time;

        public Stop(EnemyBase _machine) : base(_machine)
        {
        }

        public override void OnEnterState()
        {
            boss = (AreaBoss)machine;
            time = 0;
        }

        public override void OnUpdate()
        {
            time += Time.deltaTime;

            if (time >= 2f)
            {
                boss.ChangeState(new AreaBoss.MoveUp(boss));
            }
        }
    }
}
