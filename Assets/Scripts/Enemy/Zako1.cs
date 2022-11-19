using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zako1 : EnemyBase
{
    public GameObject popItemPref;

    private void Update()
    {
        if (this.gameObject != null)
        {
            Move();
            if (Attack_Triger)
            {
                Attack();
            }
        }

    }

    protected override void Move()
    {
        gameObject.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
    }

    protected override void PopItem()
    {
        Instantiate(popItemPref, transform.position, Quaternion.identity);
    }

}

