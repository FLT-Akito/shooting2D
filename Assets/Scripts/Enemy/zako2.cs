using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemyzako2
{


    public class zako2 : EnemyBase
    {

        //public GameObject createItem;  
        float fangle = (Mathf.PI) / 4;
        Vector2 direction;

        protected override void initialize()
        {
            StartCoroutine(StartCoru());
        }

        private void Update()
        {
            if (this.gameObject != null)
            {
                if (Attack_Triger)
                {
                    Attack();
                }
            }
           
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
                yield return StartCoroutine(MoveUp(ExcustionTime,true));
                yield return StartCoroutine(MoveUp(ExcustionTime,false));
            }
        }

        IEnumerator MoveUp(float sec, bool flag)
        {
            var timer = sec;
            float dir = 1f;

            if(!flag)
            {
                dir = -1f;
            }

            while (timer > 0)
            {
                ZakoMoving(dir * fangle * 3f);
                timer -= Time.deltaTime;
                yield return null;
               
            }
           
        }

        //IEnumerator MoveDown(float sec)
        //{
        //    var timer = sec;
        //    while (timer > 0)
        //    {
        //        ZakoMoving(-1f*fangle * 3f);
        //        timer -= Time.deltaTime;
        //        yield return null;
        //    }
        //}
      
    }
}