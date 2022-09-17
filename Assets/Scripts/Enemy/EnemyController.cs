using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public abstract class EnemyController : MonoBehaviour
{

    GameManager gameManager;
    protected EnemyGroup enemyGroup;
    protected EnemyBoss enemyBoss;
    [SerializeField] protected int score = 100;
    [SerializeField] protected int hp = 1;

    public GameObject explosion;
    public GameObject enemyBulletPref;
    private GameObject wallLeft;
    private GameObject playerShip;

    //基底クラス(継承)
    public float Speed { get; private set; } = -4f;
    public float Zako_r1 { get; set; } = 7.0f;              //zako1の中心座標
    public float Player_r2 { get; private set; } = 3.0f;   //playerの中心座標 
    public float ExcustionTime { get; set; } = 0.7f;
    public bool Attack_Triger { get; set; } = true;

    protected UnityEvent attackEvent = new UnityEvent();

    private void Start()
    {
        wallLeft = GameObject.Find("WallLeft");
        playerShip = GameObject.Find("playerShip");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        initiarise();

    }

    private void Update()
    {
        Move();
        OnAttack();
        OnUpdate();
    }

    protected virtual void Move()
    {
        gameObject.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        EnemyDestroy();
    }

    //敵がやられたら爆発する
    private void EnemyExplosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void ShotInstance(GameObject shotPrefab, Vector2 _direction)
    {
        BulletBase bullet = Instantiate(shotPrefab, this.transform.position, Quaternion.identity).GetComponent<BulletBase>();
        bullet.Init(5f, _direction);
    }

    //デッドラインを越えると自然消滅する
    protected void EnemyDestroy()
    {
        if (this.transform.position.x < wallLeft.transform.position.x)
        {
            Destroy(this.gameObject);

        }

    }

    public float Distance(Vector3 playerShip, Vector3 enemyShip)
    {
        var zako1_p1 = enemyShip;
        var player_p2 = playerShip;
        var dir = zako1_p1 - player_p2;
        var d = dir.magnitude;

        return d;
    }

    protected void Attack()
    {
        if(Attack_Triger)
        {
            if (playerShip != null)
            {
                if (Distance(playerShip.transform.position, this.transform.position) < Zako_r1 + Player_r2)
                {
                    Vector2 direction = new Vector2(playerShip.transform.position.x - this.transform.position.x, playerShip.transform.position.y - this.transform.position.y);
                    ShotInstance(enemyBulletPref, direction);
                    attackEvent.Invoke();
                    Attack_Triger = false;
                }
            }
        }
       
    }

    protected virtual void OnAttack()
    {
        Attack();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Megahone"))
        {
            DamageColor();
            hp -= 1;

            if (hp <= 0)
            {
                Destroy(gameObject);
                EnemyExplosion();
                gameManager.AddScore(score);

                if (enemyGroup != null)
                {
                    if (enemyGroup.Dead(this))
                    {
                        PopItem();

                    }
                }
                else
                {
                    PopItem();

                }

            }
        }
    }

    protected virtual void PopItem() { }

    protected virtual void initiarise() { }

    protected virtual void DamageColor() { }

    protected virtual void OnUpdate() { }

    public void SetEnemyGroup(EnemyGroup group)
    {
        enemyGroup = group;
    }

}



