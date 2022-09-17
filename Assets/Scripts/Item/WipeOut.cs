using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeOut : MonoBehaviour
{
   
    private void OnBecameVisible()
    {
        //Debug.Log("null");
        if (this.gameObject == null)
        {
            Debug.Log("null");
            //foreach(GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
            //{
            //    if(obj.activeInHierarchy)
            //    {
            //        if(obj.CompareTag("Enemy"))
            //        {
            //            Destroy(obj);
            //        }
            //    }
            //}
        }
    }

   
}
