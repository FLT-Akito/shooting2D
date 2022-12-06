using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAngle : MonoBehaviour
{
    public Transform targetTransform;
    private Vector3 targetPosvec3;
    public float targetangle;
    public float ownAngle;
    public Vector3 dir1;
    public Vector3 dir2;
    // Start is called before the first frame update
    void Start()
    {
       
        //targetPosvec3 = targetTransform.position;
        //targetPosvec3 = Vector3.right;
        //angle = Vector3.Angle(targetTransform.position, transform.position);
        //Debug.Log(angle);
       
    }

    // Update is called once per frame
    void Update()
    {
         dir1 = transform.position - targetTransform.transform.position;
         dir2 = targetTransform.transform.position - transform.position;
        //targetangle = Vector3.Angle(targetTransform.position, transform.position);
        ownAngle = Vector3.Angle(targetTransform.position, dir2);
       
    }
}
