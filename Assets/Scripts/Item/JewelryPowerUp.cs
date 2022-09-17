using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelryPowerUp : MonoBehaviour
{
    public GameObject player;
    private float time;
    private bool setTime;
    void Start()
    {
       
    }

    // Update is called once per frame
   public void Update()
    {
        
        for(int i = 1; i <= 3; i++)
        {
            player.transform.localPosition = new Vector3(i, i, i)*Time.deltaTime;
        }
       
       
    }
    private bool SetTime(bool settime)
    {
        return setTime = settime;
    }
}
