using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public abstract class EnemyBase : StateMachineBase<EnemyBase>
{

    //GameManager gameManager;
    UIController uiController;
    protected EnemyGroup enemyGroup;
    protected EnemyBoss enemyBoss;
    [SerializeField] protected int score = 100;
    [SerializeField] protected int hp = 1;

    public GameObject explosion;
    public GameObject enemyBulletPref;
   
    protected GameObject playerShip;
    protected UnityEvent attackEvent = new UnityEvent();

    public float Speed { get; private set; } = -4f;
    public float Zako_r1 { get; set; } = 7.0f;              //zako1�̒��S���W
    public float Player_r2 { get; private set; } = 3.0f;   //player�̒��S���W 
    public float ExcustionTime { get; set; } = 0.7f;
    public bool Attack_Triger { get; set; } = true;
    public GameObject Player => playerShip;
    private bool cameraVeiw;
   

    private void Start()
    {
      
        playerShip = GameObject.Find("playerShip");
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        initialize();
    }

    //�G�����ꂽ�甚������
    private void EnemyExplosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void ShotInstance(GameObject shotPrefab)
    {
        Vector2 _direction = GetShotDirection();
        BulletBase bullet = Instantiate(shotPrefab, GetShotPosition(), Quaternion.identity).GetComponent<BulletBase>();
        bullet.Init(5f, _direction);

    }

    protected virtual Vector2 GetShotPosition()
    {
        return this.transform.position;
    }
   
    public float Distance(Vector3 playerShip, Vector3 enemyShip)
    {
        var zako1_p1 = enemyShip;
        var player_p2 = playerShip;
        var dir = zako1_p1 - player_p2;
        var d = dir.magnitude;

        return d;
    }

    protected virtual void Attack()
    {
        if (playerShip != null)
        {
            if (Distance(playerShip.transform.position, this.transform.position) < Zako_r1 + Player_r2)
            {
                ShotInstance(enemyBulletPref);
                attackEvent.Invoke();
                Attack_Triger = false;
            }
        }
    }

    protected virtual Vector2 GetShotDirection()
    {
        return new Vector2(playerShip.transform.position.x - this.transform.position.x, playerShip.transform.position.y - this.transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //�f�b�h���C�����z����Ǝ��R���ł���
        if (collision.gameObject.CompareTag("DeadLine"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Megahone"))
        {

            TakeDamage(1);

        }
    }

    public void TakeDamage(int damage)
    {
        DamageColor();
        hp -= damage;

        if (hp <= 0)
        {
            Eliminated();

        }
    }

    public void Eliminated()
    {
        Destroy(gameObject);
        EnemyExplosion();
        uiController.AddScore(score);

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

    private void OnWillRenderObject()
    {
        if (Camera.current.tag == "MainCamera")
        {
            cameraVeiw = true;
        }
    }

    private void OnBecameInvisible()
    {
        cameraVeiw = false;
    }

    public bool IsCameraVeiw()
    {
        return cameraVeiw;
    }


    protected virtual void Move() { }

    protected virtual void initialize() { }

    protected virtual void DamageColor() { }

    protected virtual void PopItem() { }
    //protected virtual void OnUpdate() { }

    public void SetEnemyGroup(EnemyGroup group)
    {
        enemyGroup = group;
    }

}



