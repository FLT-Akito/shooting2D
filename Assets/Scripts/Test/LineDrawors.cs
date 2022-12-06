using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawors : MonoBehaviour
{
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"ローカル座標：{transform.localRotation} ワールド座標:{transform.rotation}");
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       // line.SetPosition(1, gameObject.transform.position);

    }
}
