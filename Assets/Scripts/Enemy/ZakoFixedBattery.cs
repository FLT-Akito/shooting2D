using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoFixedBattery : EnemyController
{
    /*
     * ��肽������
     * ��莞�Ԃ��ƂɍU��������
     * 
     * �ǂ�����Ύ����ł��邩
     * Attack()���\�b�h�����̎��Ԃ��o�߂�����Ăяo��
     */
    private float time;
    private bool isAttack = true;
    public float atkTime;

    private GameObject wallRight;
    

    protected override void initialize()
    {
        wallRight = GameObject.Find("WallRight");
        attackEvent.AddListener(() =>
        {
            //Debug.Log("listener");
            time = 0f;
        });
     
    }

    
    private void Update()
    {
        if (isAttack)
        {
            Attack();
        }

        if (wallRight.transform.position.x >= this.gameObject.transform.position.x)
        {
           
            isAttack = false;
            time += Time.deltaTime;

            if (time > atkTime)
            {
                Attack();
                //OnAttack();
                Attack_Triger = true;
                //time = 0;
            }
        }
    }
   
    //protected override void OnUpdate()
    //{
    //   // Debug.Log(time);
    //    time += Time.deltaTime;
    //    if (time > atkTime)
    //    {
    //        //OnAttack();
    //        Attack_Triger = true;
    //        //time = 0;
    //    }

    //}

}
