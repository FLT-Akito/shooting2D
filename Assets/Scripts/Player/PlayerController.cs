using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float speedUpRate = 1.0f;
    private bool isSpeedUp = true;
    private bool isGigant = false;
    private const float maxSpeed = 10f;
    private const int maxOptions = 4;
    private WeaponBase weaponMain;
    private WeaponBase weaponSub;
    private WeaponBase weaponMainTemp;
    private WeaponBase weaponSubTemp;
    private CircleCollider2D circle;
    private PolygonCollider2D polygon;
    private int count = 0;
    public Vector3[] positionHistories = new Vector3[300];
    private Vector3 positionLast;
    private List<GameObject> optionList = new List<GameObject>();
    [SerializeField] GameObject bomItem;
    [SerializeField] GameObject megahone;
    [SerializeField] WeaponDouble weaponDouble;
    [SerializeField] WeaponLaser weaponLaser;
    [SerializeField] WeaponNormal weaponNomal;
    [SerializeField] WeaponMissile weaponMissile;
    //[SerializeField] Transform OptionPosi;
    //[SerializeField] Transform laserShot;
    [SerializeField] GameObject Hit;
    [SerializeField] GameObject option;
    [SerializeField] GameManager gameManager;
    public WipeOut wipeOut;
    Rigidbody2D rigi;
    Animator animator;
    public string leftAnimator = "PlayerLeft Animation";
    public string rightAnimator = "PlayerRight Animation";
    public string stopAnimator = "PlayerIdleAnimation";
    private string nowAnime = "";
    public float PlayerSpeed
    {
        get
        {
            return speed * speedUpRate;
        }
    }

    public enum DIRECTION_TYPE
    {
        STOP,
        LEFT,
        RIGHT
    }

    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;
    //JEWELRYCOLORTYPE jewelryColorType = JEWELRYCOLORTYPE.TOPAZ;
    void Start()
    {

        circle = GetComponent<CircleCollider2D>();
        polygon = GetComponent<PolygonCollider2D>();
        rigi = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nowAnime = stopAnimator;
        weaponMain = weaponNomal; //�ʏ�e��weaponNomal
        weaponSub = null;
        
        //dotween Ease ��ނŒ��ׂ�
    }

   
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (x == 0)     �@�@�@�@�@�@�@�@�@�@�@�@// ���������̈ړ�
        {
            direction = DIRECTION_TYPE.STOP;     // ���x���O�̎��X�g�b�v�̃A�j���[�V����
            nowAnime = stopAnimator;
        }

        float y = Input.GetAxisRaw("Vertical");�@�@

        if (y == 0)
        {
            direction = DIRECTION_TYPE.STOP;�@�@�@�@�@
            nowAnime = stopAnimator;
        }
        if (y > 0)
        {
            direction = DIRECTION_TYPE.LEFT;�@�@�@�@�@
            nowAnime = leftAnimator;
        }
        if (y < 0)
        {
            direction = DIRECTION_TYPE.RIGHT;�@�@�@�@�@
            nowAnime = rightAnimator;
        }

        //Player: �p���[�A�b�v����
        if (Input.GetKeyDown(KeyCode.F1))
        {
            POWERUPTYPE poweruptype;

            if (gameManager.WeaponItemCount(out poweruptype))
            {
                PlayerPowerUp(poweruptype);

            }

        }

        //�A�j���[�V�����̐؂�ւ�
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                animator.Play(nowAnime);
                break;

            case DIRECTION_TYPE.LEFT:
                animator.Play(nowAnime);
                break;

            case DIRECTION_TYPE.RIGHT:
                animator.Play(nowAnime);
                break;
        }

        //player�����ł����烊�g���C�{�^����������
        if (this.gameObject == null)
        {
            RetrayPress();
        }

        //Option��Player�̉ߋ��̋O��
        if(this.transform.position != positionLast || (x!= 0f || y !=0f))
        {
            for (int i = positionHistories.Length-1; i > 0; i--)
            {
                positionHistories[i] = positionHistories[i-1];
            }
            
            positionHistories[0] = transform.position;
            positionLast = this.transform.position;

            for(int i = 0; i < optionList.Count; i++)
            {
                optionList[i].transform.position = positionHistories[(i+1) * 100];
            }
        }

        //�U��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (weaponMain != null)
            {
                weaponMain.SetShotRequest(true);

            }

            if (weaponSub != null)
            {
                weaponSub.SetShotRequest(true);

            }

        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (weaponMain != null)
            {
                weaponMain.SetShotRequest(false);

            }

            if (weaponSub != null)
            {
                weaponSub.SetShotRequest(false);

            }

        }
    }
  
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rigi.velocity = new Vector2(x, y) * PlayerSpeed;
    }

    public void PlayerPowerUp(POWERUPTYPE powerupType)
    {
        switch (powerupType)
        {
            case POWERUPTYPE.SPEED:

                if (isSpeedUp)
                {
                    speedUpRate += 0.2f;
                }

                if (PlayerSpeed >= maxSpeed)
                {
                    isSpeedUp = false;
                    gameManager.WeaponTextErace(powerupType);

                }
                break;

            case POWERUPTYPE.MISSILE:
                weaponSub = weaponMissile;
                gameManager.WeaponTextErace(powerupType);
                break;

            case POWERUPTYPE.DOUBLE:
                weaponMain = weaponDouble;
                gameManager.WeaponTextErace(powerupType);
                break;

            case POWERUPTYPE.LASER:
                weaponMain = weaponLaser;
                gameManager.WeaponTextErace(powerupType);
                break;

            case POWERUPTYPE.OPTION: //Player�̎q�Ƃ��Đ����B�ő�4�B
                count++;
                //var ofsetX = -1.0f;
                if(option != null)
                {
                    if (count <= maxOptions)
                    {
                        GameObject op = Instantiate(option, this.transform.position, Quaternion.identity);
                        WeaponLaser laser = op.GetComponentInChildren<WeaponLaser>();
                        laser.Player = op;
                        //for(int i = count; count <= maxOptions; i++)
                        //{
                        //    var targetPosLeft = new Vector3(transform.position.x + (ofsetX - i),
                        //        transform.position.y, transform.position.z);
                        //   op = Instantiate(option, targetPosLeft, Quaternion.identity);
                        //}
                        op.transform.SetParent(this.transform); 
                       // OptionPosi.position -= _optionPosition;
                        if (count == maxOptions)
                        {
                            gameManager.WeaponTextErace(powerupType);
                        }
                        optionList.Add(op);
                    }
                }
                break;

            case POWERUPTYPE.OH:
                weaponMain = weaponNomal;
                weaponSub = null;
                option = null;
                gameManager.ResetText();
                break;

            case POWERUPTYPE.F_FILED: //FILED�ɂ͑ϋv�l����������
                break;
        }
    }

    public void Jewerys(JEWELRYCOLORTYPE jewelryColorType)
    {
        switch (jewelryColorType)
        {
            case JEWELRYCOLORTYPE.TOPAZ:�@�@//�X�R�A�A�b�v(500�_)
                gameManager.AddScore(500);
                break;

            case JEWELRYCOLORTYPE.AMETHYST: //��ʓ��̓G�����ׂĔj��

                break;

            case JEWELRYCOLORTYPE.DIAMOND:  //���K�z���ɂ��ђʍU��
                megahone.SetActive(true);
                weaponMainTemp = weaponMain;
                weaponSubTemp = weaponSub;
                weaponMain = null;
                weaponSub = null;
                StartCoroutine(DelayMethod(8f, () =>
                {
                    megahone.SetActive(false);
                    weaponMain = weaponMainTemp;
                    weaponSub = weaponSubTemp;
                }));
               
                break;

            case JEWELRYCOLORTYPE.EMERALD:  //Player���g��G���e�͑łĂȂ������G�ɂȂ�
                weaponMainTemp = weaponMain;
                weaponSubTemp = weaponSub;
                weaponMain = null;
                weaponSub = null;
                isGigant = true;
                circle.enabled = false;
                polygon.enabled = true;
                transform.DOScale(3f, 3f).SetEase(Ease.Linear).OnComplete(()=>
                {
                     
                    transform.DOScale(1f, 3f).SetDelay(7f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        weaponMain = weaponMainTemp;
                        weaponSub = weaponSubTemp;
                        isGigant = false;
                        polygon.enabled = false;
                        circle.enabled = true;
                    });
                   
                });
               
               
                break;

            case JEWELRYCOLORTYPE.GARMET:   //��ʓ��ɂ���G��j�󂷂�A�C�e���ő吔�P
                bomItem.SetActive(true);
                break;

            case JEWELRYCOLORTYPE.RUBY:�@�@//�X�R�A�A�b�v
                gameManager.AddScore(1000);
                break;
        }
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet")||collision.gameObject.CompareTag("Stage"))
        {
            Vector2 hitPoint = transform.position;
            if (isGigant)
            {
                hitPoint = collision.transform.position;
                
            }
            else
            {
                Destroy(this.gameObject);
                gameManager.GameOver();
            }
            
            Instantiate(Hit, hitPoint, transform.rotation);
            if(!collision.gameObject.CompareTag("Stage"))
            {
                Destroy(collision.gameObject);
            }
            
        }

        if (collision.gameObject.CompareTag("Pwitem"))
        {
            //var item = new GameObject().AddComponent<ItemNotice>();
            Destroy(collision.gameObject);
            gameManager.SetItems();
        }

        //if(collision.gameObject.CompareTag("WipeoutItem"))
        //{
            
        //    Destroy(collision.gameObject);
        //}

        if (collision.gameObject.CompareTag("Jewelry"))
        {
            ItemJewelry jewelry = collision.gameObject.GetComponent<ItemJewelry>();
            JEWELRYCOLORTYPE jewelryColorType = jewelry.GetJewelryColorType();
            Jewerys(jewelryColorType);
            Destroy(collision.gameObject);          
        }
    }

    private void RetrayPress()
    {
        gameManager.OnPressRetryButton();
    }

   
}
