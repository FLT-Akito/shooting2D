using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum POWERUPTYPE
{
    SPEED,
    MISSILE,
    DOUBLE,
    LASER,
    OPTION,
    OH,
    F_FILED
}

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject retryButton;
    public GameObject lifeUI;
    public GameObject canvas;
   // public GameObject playerUI;
    public Stack<GameObject> playerUIobj;
    public Text playerLife;
    public Text ScoreText;
    public Text MissileText;
    public Text SpeedText;
    public Text LaserText;
    public Text DoubleText;
    public Text F_FieldText;
    public Text OptionText;
    public Text OhText;
    public POWERUPTYPE[] poweruplist;
    public int score = 0;
    int itemCount = 0;
    int oneUpScore = 25000;
    int oneUpCount = 1;
    int maxOneup = 10;
    Vector3 pUIobj;
    Dictionary<POWERUPTYPE, Text> weaponText;
    GameObject[] items;
    GameObject[] itemsData;
    GameObject ob;
    SpriteRenderer sr;
    //private bool isWeaponTextErace;
    //public bool IsEraceText => isWeaponTextErace;

    void Start()
    {
        weaponText = new Dictionary<POWERUPTYPE, Text>()
        {
            [POWERUPTYPE.MISSILE] = MissileText,
            [POWERUPTYPE.SPEED] = SpeedText,
            [POWERUPTYPE.DOUBLE] = DoubleText,
            [POWERUPTYPE.F_FILED] = F_FieldText,
            [POWERUPTYPE.OPTION] = OptionText,
            [POWERUPTYPE.LASER] = LaserText
        };

       items = GameObject.FindGameObjectsWithTag("Item");
       itemsData = new GameObject[items.Length];
       gameOverText.SetActive(false);

        //Debug.Log(lifeUI.transform.position);

        Transform tf = canvas.transform;
        pUIobj = tf.position;
        pUIobj.x += 63f;
        tf.position = pUIobj;
       GameObject obj = Instantiate(lifeUI, tf, true);
        //Debug.Log(obj.transform.position);
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
    }

    public void OnPressRetryButton()
    {
        SceneManager.LoadScene("Stage1");
        
    }

    public void AddScore(int _score)
    {
        score += _score;
        ScoreText.text = "SCORE:" + this.score;
        if(score == oneUpScore)
        {
            oneUpScore += 25000;
            oneUpCount++;

            if(oneUpCount != maxOneup)
            {
               
                Instantiate(lifeUI, transform.position = new Vector3(-735f,400f,0), Quaternion.identity);
                //pUIobj = uiobj.transform.position;
                //pUIobj.x += 63f;
                //playerUIobj.Push(uiobj);
            }
        }
    }

    public void WeaponTextErace( POWERUPTYPE powerupType)
    {
        
        if(weaponText[powerupType].text != null)
        {
            weaponText[powerupType].text = "";           
        }
       
    }

    public void ResetText()
    {
        MissileText.text = "MISSILE";
        SpeedText.text = "SPEED";
        DoubleText.text = "DOUBLE";
        LaserText.text = "LASER";
        F_FieldText.text = "F.FILED";
        OhText.text = "OH";
        OptionText.text = "OPTION";
    }

    public void SetItems()
    {
        itemCount++;
        if (itemCount > itemsData.Length)
        {
            itemCount = 1;
        }
    
        SetUpItem(itemCount);
    }

    public void SetUpItem(int itemIndex)
    {
        
        for(int i = 1; i < itemsData.Length+1; i++)
        {
            
            var sr = items[i-1].GetComponent<Image>();
             if(i == itemIndex)
            {
                sr.color = Color.green;
            }
             else
            {
                sr.color = Color.white;
            }
        }
        
    }

    public bool WeaponItemCount(out POWERUPTYPE poweruptype)
    {
        poweruptype = POWERUPTYPE.SPEED;
        if(itemCount > 0)
        {
           // Debug.Log(poweruplist[itemCount - 1]);
            poweruptype = poweruplist[itemCount - 1];
            itemCount = 0;
            SetUpItem(itemCount);
            return true;
        }
        return false;
       
    }

}
