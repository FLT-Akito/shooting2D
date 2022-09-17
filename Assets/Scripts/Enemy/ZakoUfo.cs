using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoUfo : EnemyController
{
   
    public GameObject zakoUfo;
    public GameObject createItem;
    public float amp;
    public float deg;
    ZakoUfo ufo;
    float speed = 1.5f;
   // bool isApear = true;

    protected override void PopItem()
    {
        Instantiate(createItem, transform.position, Quaternion.identity);
    }


    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            for (int i = 1; i <= 7; i++)
            {
                ufo = Instantiate(zakoUfo, transform.position, Quaternion.identity).GetComponent<ZakoUfo>();

            }

        }
        if (ufo != null)
        {

            MoveSinWave();
           
        }
    }

    void MoveSinWave()
    {
        
        float rad = deg * Mathf.Deg2Rad;
        transform.position -= new Vector3(speed * Time.deltaTime,
                                 amp * Time.deltaTime  * Mathf.Sin(Time.time+rad), 0);
        //ASin(É÷t+Éø): ê≥å∑îgÅ@
        //A:êUïù,(É÷t+Éø):à ëä(äpìx)
    }

    void ZakoUfoApear()
    {
       
    }

   
    //protected override void Exprode()
    //{
    //    EnemyExplosion(this.gameObject, Explosion);
    //}


}
