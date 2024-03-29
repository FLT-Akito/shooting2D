using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJewelry : Item,IWipedOut
{
    public JEWELRYCOLORTYPE[] jewelryTypeList;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    float initSpeed = 5f;
    float gravity = -0.01f;
    int changeColor = 0;
    int maxCount = 3;
    int count = 0;

    Vector3 position;
    Vector3 velocity;
   

    public JEWELRYCOLORTYPE GetJewelryColorType()
    {
        return jewelryTypeList[changeColor];
    }

    protected override void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        position = transform.position;
        velocity.x = 0; 
    }
   
    protected override void Tick()
    {
        position.x += velocity.x * Time.deltaTime;
        velocity.x += gravity;
        transform.position = position;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet")||collision.gameObject.CompareTag("Megahone"))
        {
            velocity.x = initSpeed;
            count++;
            PlayerBullet playerBullet = collision.gameObject.GetComponent<PlayerBullet>();
            if (maxCount == count)
            {
                changeColor++;
                changeColor %= sprites.Length;
                spriteRenderer.sprite = sprites[changeColor];
                count = 0;
            }
            if (playerBullet != null)
            {
                Destroy(playerBullet.gameObject);
            }
        }
    }

    public void WipedOut()
    {
        GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject obj in gameObjects)
        {
            EnemyBase enemy = obj.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                if (enemy.IsCameraVeiw())
                {
                    if (enemy.tag == "Enemy")
                    {
                        enemy.Eliminated();
                    }
                }
            }
        }
    }
}
