using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemyzako1
{

    public class Zako1 : EnemyController
    {
        public GameObject creatItem;

        protected override void PopItem()
        {

            Instantiate(creatItem, transform.position, Quaternion.identity);
        }
    }
}
