using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MegahoneController : MonoBehaviour
{
    public List<Sprite> wordAttack = new List<Sprite>();
    public GameObject MegahoneParent;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxColider2D;
    
    void Start()
    {
        //_parent = transform.root.gameObject;
        //Debug.Log("Parent:" + _parent.name);
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxColider2D = GetComponent<BoxCollider2D>();
        StartCoroutine("WordChanger");
        
    }

    
     IEnumerator WordChanger()
    {     
        int changeSpritecounter = 0;
        spriteRenderer.sprite = wordAttack[changeSpritecounter];
        boxColider2D.enabled = true;

        while (MegahoneParent.activeSelf)
        {
            yield return new WaitForSeconds(3f);
            changeSpritecounter++;

            spriteRenderer.sprite = wordAttack[changeSpritecounter % wordAttack.Count];
            if (MegahoneParent.activeSelf == false)
            {
                break;
            }
        }
    }

  
}
