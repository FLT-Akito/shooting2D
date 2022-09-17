using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemyzako2
{


    public class zako2 : EnemyController
    {
       
        public GameObject createItem;  
        float fangle = (Mathf.PI) / 4;
        Vector2 direction;

        protected override void initiarise()
        {
 
            StartCoroutine(StartCoru());
        }

        protected override void PopItem()
        {
            Instantiate(createItem, transform.position, Quaternion.identity);
        }

        //protected override void OnUpdate()
        //{
        //    EnemyDestroy();
        //}

        public void ZakoMoving(float rajian)
        {
            direction.x = Mathf.Cos(rajian);
            direction.y = Mathf.Sin(rajian);

            transform.Translate(direction.x * -Speed * Time.deltaTime,
                                 direction.y * -Speed * Time.deltaTime, 0);
        }

        IEnumerator StartCoru()
        {

            while (this.gameObject != null)
            {
                yield return StartCoroutine(MoveUp(ExcustionTime));
                yield return StartCoroutine(MoveDown(ExcustionTime));
            }
        }

        IEnumerator MoveUp(float sec)
        {
            var timer = sec;
            while (timer > 0)
            {
                ZakoMoving(fangle * 3f);
                timer -= Time.deltaTime;
                yield return null;
               
            }
           
        }

        IEnumerator MoveDown(float sec)
        {
            var timer = sec;
            while (timer > 0)
            {
                ZakoMoving(-fangle * 3f);
                timer -= Time.deltaTime;
                yield return null;
            }
        }
      
    }
}