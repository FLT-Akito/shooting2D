using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    private float bulletSpeed = 10f;
    private float dx;
    private float dy;

    private void Update()
    {
        transform.position += new Vector3(dx, dy, 0f) * bulletSpeed * Time.deltaTime;
    }

    public void SetBulletAngle(float angle)
    {
        dx = Mathf.Cos(angle);
        dy = Mathf.Sin(angle);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadLine"))
        {
            Destroy(this.gameObject);
        }
    }
}
