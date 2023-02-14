using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum POWERUPTYPE
{
    SPEED,
    MISSILE,
    DOUBLE,
    LASER,
    OPTION,
    OH,
}

public class UIController : MonoBehaviour
{

    public GameObject lifeUIpref;

    public Text ScoreText;
    public Text MissileText;
    public Text SpeedText;
    public Text LaserText;
    public Text DoubleText;
    public Text OptionText;
    public Text OhText;

    public Dictionary<POWERUPTYPE, Text> weaponText;

    public POWERUPTYPE[] poweruplist;

    private int itemCount = 0;
    private int lifeUpScore = 25000;

    GameObject[] powerUpUI;
    GameObject[] powerUpUIData;

    public GameObject lifeUILayout;
    private Stack<GameObject> lifeUIList = new Stack<GameObject>();

    private float setRouletteTimer = 0;
    public float rouletteSpeed;

    public bool IsWeaponTextErase { get; private set; }

    void Start()
    {
        weaponText = new Dictionary<POWERUPTYPE, Text>()
        {
            [POWERUPTYPE.MISSILE] = MissileText,
            [POWERUPTYPE.SPEED] = SpeedText,
            [POWERUPTYPE.DOUBLE] = DoubleText,
            [POWERUPTYPE.OPTION] = OptionText,
            [POWERUPTYPE.LASER] = LaserText,
            [POWERUPTYPE.OH] = OhText
        };
       
        powerUpUI = GameObject.FindGameObjectsWithTag("PowerUpUI");
        powerUpUIData = new GameObject[powerUpUI.Length];

        ScoreText.text = "SCORE:" + ScoreManager.score;
        ShowLife(LifeCountManager.lifeCount);

    }

    public void ShowLife(int life)
    {
        int loopCount = lifeUIList.Count;

        for (int i = 0; i < loopCount; i++)
        {
            var popLifeUI = lifeUIList.Pop();
            Destroy(popLifeUI);
        }

        for (int i = 0; i < life; i++)
        {
            GameObject obj = Instantiate(lifeUIpref);
            lifeUIList.Push(obj);
            obj.transform.SetParent(lifeUILayout.transform);
        }
    }

    public void AddScore(int _score)
    {
        ScoreManager.score += _score;
        ScoreText.text = "SCORE:" + ScoreManager.score;

        if (ScoreManager.score >= lifeUpScore)
        {
            AddLifeUI();
        }
    }

    private void AddLifeUI()
    {
        lifeUpScore += lifeUpScore;

        if (LifeCountManager.lifeCount < Define.MAX_LIFE_COUNT)
        {
            LifeCountManager.lifeCount++;
            ShowLife(LifeCountManager.lifeCount);
        }
        else
        {
            LifeCountManager.lifeCount = Define.MAX_LIFE_COUNT;
        }
    }

    public void WeaponTextErace(POWERUPTYPE powerupType)
    {
        if (weaponText[powerupType].text != null)
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
        OhText.text = "OH";
    }

    public void SetItems()
    {
        itemCount++;
        if (itemCount > powerUpUIData.Length)
        {
            itemCount = 1;
        }

        SetUpItem(itemCount);
    }

    public void SetUpItem(int itemIndex)
    {
        for (int i = 1; i < powerUpUIData.Length + 1; i++)
        {
            var sr = powerUpUI[i - 1].GetComponent<Image>();
            if (i == itemIndex)
            {
                sr.color = Color.green;
                
                if(weaponText[(POWERUPTYPE)itemIndex - 1].text == "")
                {
                    IsWeaponTextErase = true; //•Ï”–¼‚ªˆ«‚¢‚©‚ç•ÏX‚·‚é
                }
                else
                {
                    IsWeaponTextErase = false;
                }
            }
            else
            {
                sr.color = Color.white;
            }
        }
    }

    //private void CheckPowerUpText(int itemIndex,out POWERUPTYPE powerUpType)
    //{
    //    powerUpType = POWERUPTYPE.SPEED;
    //}

    public void RouletteStart(bool isRoulette)
    {
        if (isRoulette)
        {
            setRouletteTimer += rouletteSpeed * Time.deltaTime;
            itemCount = (int)setRouletteTimer;

            if (itemCount > powerUpUIData.Length)
            {
                setRouletteTimer = 1;
            }

            SetUpItem(itemCount);
        }
    }

    public bool WeaponItemCount(out POWERUPTYPE poweruptype)
    {
        poweruptype = POWERUPTYPE.SPEED;

        if (itemCount > 0)
        {
            poweruptype = poweruplist[itemCount - 1];
            itemCount = 0;
            SetUpItem(itemCount);
            return true;
        }

        return false;
    }
}
