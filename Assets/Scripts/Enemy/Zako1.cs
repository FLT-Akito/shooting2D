using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zako1 : EnemyController
{
    private void Update()
    {
        if (this.gameObject != null)
        {       
            Move();
            Attack();
        }
    
    }

    private void Move()
    {
        gameObject.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
    }

}

