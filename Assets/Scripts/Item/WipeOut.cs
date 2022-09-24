using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeOut : MonoBehaviour
{
   
    private void OnBecameVisible()
    {
        if (this.gameObject == null)
        {
            Debug.Log("null");
        }
    }
}
