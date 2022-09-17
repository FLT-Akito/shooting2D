using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class EnemyBoss : EnemyController
{
   
    //public Item jewelry;
    public GameObject jewelry;
    //private GameObject limit_WallLeft;
    private SpriteRenderer middleBossImageColor;
    private int repetition = 8; //反復回数（ダメージ、点滅演出）
    public float duration = 0.001f;
    [SerializeField] [Range(-1.0f, 1.0f)] private float period = 0.4f;

   
    protected override void initiarise()
    {
       // limit_WallLeft = GameObject.Find("WallLeft");
        middleBossImageColor = GetComponent<SpriteRenderer>();


    }

    protected override void OnUpdate()
    {
        EnemyDestroy();
    }
    

    protected override void DamageColor()
    {
        Sequence _seq;
        _seq = DOTween.Sequence();
        _seq.Append(middleBossImageColor.DOColor(Color.red, duration).SetEase(Ease.OutFlash, repetition, period));
        _seq.Append(middleBossImageColor.DOColor(Color.white, duration).SetEase(Ease.OutFlash, repetition, period));
        _seq.Play();
    }


    protected override void PopItem()
    {
        //jewelry.JemApear(this.gameObject);
        Instantiate(jewelry, transform.position, Quaternion.identity);
    }

    protected override void Move() { }
    protected override void OnAttack() { }
}
