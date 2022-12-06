using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoBat : EnemyBase
{
    private Vector2 dirVec;
    private float speed = 2f;

    protected override void initialize()
    {
        dirVec = new Vector2(-1f, -1f);
    }
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject != null && IsCameraVeiw())
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
        if (this.transform.position.y > 1f)
        {
            dirVec.y = -1f;
        }

        if (this.transform.position.y < -2f)
        {
            dirVec.y = 1f;
        }

        transform.Translate(dirVec * speed * Time.deltaTime);
    }
}
