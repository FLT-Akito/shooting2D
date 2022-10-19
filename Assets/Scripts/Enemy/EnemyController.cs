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
    public GameObject popItemPref;
    //private GameObject wallLeft;
    private GameObject playerShip;

    //���N���X(�p��)
    public float Speed { get; private set; } = -4f;
    public float Zako_r1 { get; set; } = 7.0f;              //zako1�̒��S���W
    public float Player_r2 { get; private set; } = 3.0f;   //player�̒��S���W 
    public float ExcustionTime { get; set; } = 0.7f;
    public bool Attack_Triger { get; set; } = true;
    public bool cameraVeiw;
    protected UnityEvent attackEvent = new UnityEvent();

    private void Start()
    {
        //wallLeft = GameObject.Find("WallLeft");
        playerShip = GameObject.Find("playerShip");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        initialize();

    }

    //protected virtual void Move()
    //{
    //    gameObject.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
    //    //EnemyDestroy();
    //}

    //�G�����ꂽ�甚������
    private void EnemyExplosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void ShotInstance(GameObject shotPrefab, Vector2 _direction)
    {
        BulletBase bullet = Instantiate(shotPrefab, this.transform.position, Quaternion.identity).GetComponent<BulletBase>();
        bullet.Init(5f, _direction);

    }


    //protected void EnemyDestroy()
    //{
    //    if (this.transform.position.x < wallLeft.transform.position.x)
    //    {
    //        Destroy(this.gameObject);

    //    }

    //}

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
        if (Attack_Triger)
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

    //protected virtual void OnAttack()
    //{
    //    Attack();
    //}

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

    private void OnWillRenderObject()
    {
        //if (Camera.current.name != "SceneCamera" && Camera.current.name != "Preview Camera")


        //{

        //    
        //}

        if(Camera.current.tag == "MainCamera")
        {
            cameraVeiw = true;
        }
    }

    private void OnBecameInvisible()
    {
        cameraVeiw = false;
    }

    //private void OnBecameVisible()
    //{
    //    cameraVeiw = true;
    //    //Debug.Log(Camera.current.name);
    //}

    public bool IsCameraVeiw()
    {

        return cameraVeiw;
        //if(cameraView)
        //{
        //    return true;
        //}
        //return false;
    }

    private void PopItem()
    {
        Instantiate(popItemPref, transform.position, Quaternion.identity);
    }

    protected virtual void Move() { }

    protected virtual void initialize() { }

    protected virtual void DamageColor() { }
    //protected virtual void OnUpdate() { }

    public void SetEnemyGroup(EnemyGroup group)
    {
        enemyGroup = group;
    }

}



