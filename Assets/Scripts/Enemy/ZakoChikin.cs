using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoChikin : ZakoFixedBatteryBase
{
    public GameObject createItem;

    protected override void PopItem()
    {
        Instantiate(createItem, transform.position, Quaternion.identity);
    }
}
